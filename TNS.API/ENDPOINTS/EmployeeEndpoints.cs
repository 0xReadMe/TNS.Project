﻿
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.EMPLOYEES;
using TNS.APPLICATION.SERVICES.EMPLOYEE;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.EMPLOYEE;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.CORE.VO;

namespace TNS.API.ENDPOINTS
{
    public static class EmployeeEndpoints
    {
        public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("employee/getAll", GetAllEmployees);
            app.MapGet("employee/get/{id:guid}", GetEmployeeById);

            app.MapPost("employee/login", Login);

            app.MapPost("employee/add", AddEmployee);

            app.MapPut("employee/edit/{id:guid}", EditEmployee);

            app.MapDelete("employee/delete/{id:guid}", DeleteEmployee);

            return app;
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> Login(EmployeeService employeeService, [FromBody] Login_POST login)
        {
            PhoneNumber number = PhoneNumber.Create(login.Login).Value;
            var r = await employeeService.Login(number, login.Password);
            if(r.IsFailure) return Results.BadRequest("Invalid login or password.");

            var RoleId = await employeeService.GetRoleId(r.Value.Id);

            GetAllEmployees_GET getEmployee = new(r.Value.Id, RoleId.Value, r.Value.FullName, r.Value.PhotoId, r.Value.DateOfBirth, r.Value.Telegram, r.Value.Email.email, r.Value.Login.Number, r.Value.Password);

            return Results.Ok(getEmployee);
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteEmployee(EmployeeService employeeService, [FromRoute] Guid id)
        {
            var result = await employeeService.DeleteEmployee(id);
            if (result.IsFailure) return Results.BadRequest($"{result.Error}");
            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> EditEmployee([FromRoute] Guid id, [FromBody] EditEmployee_PUT r, EmployeeService employeeService)
        {
            Result<PhoneNumber> phone = PhoneNumber.Create(r.Login);
            Result<Email> email = Email.Create(r.Email);
            if (phone.IsFailure) return Results.BadRequest($"{phone.Error}");
            if (email.IsFailure) return Results.BadRequest($"{email.Error}");

            var password = employeeService.GetEmployeeByGuid(id);
            Result<Employee> emp = Employee.Create(r.FullName, r.PhotoId, r.Telegram, r.DateOfBirth, email.Value, phone.Value, password.Result.Value.Password);
            if (emp.IsFailure) return Results.BadRequest($"{emp.Error}");
            
            var result = await employeeService.UpdateEmployee(emp.Value, id);

            if (result.IsFailure) return Results.BadRequest($"BadRequestEmployee: {result.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> AddEmployee([FromBody] AddEmployee_POST r, EmployeeService employeeService)
        {
            Result<PhoneNumber> phone = PhoneNumber.Create(r.Login);
            Result<Email> email = Email.Create(r.Email);
            if (phone.IsFailure) return Results.BadRequest($"{phone.Error}");
            if (email.IsFailure) return Results.BadRequest($"{email.Error}");

            Result<Employee> emp = Employee.Create(r.FullName, r.PhotoId, r.Telegram, r.DateOfBirth, email.Value, phone.Value, r.PasswordHash);
            if (emp.IsFailure) return Results.BadRequest($"{emp.Error}");

            var result = await employeeService.AddEmployee(emp.Value, r.RoleId);

            if (result.IsFailure) return Results.BadRequest($"BadRequestEmployee: {result.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetEmployeeById(EmployeeService employeeService, [FromRoute] Guid id)
        {
            var r = (await employeeService.GetEmployeeByGuid(id)).Value;

            var roleId = (await employeeService.GetRoleId(r.Id)).Value;

            GetAllEmployees_GET getEmployee = new(r.Id, roleId, r.FullName, r.PhotoId, r.DateOfBirth, r.Telegram, r.Email.email, r.Login.Number, r.Password);

            return Results.Ok(getEmployee);
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllEmployees(EmployeeService employeeService)
        {
            List<Employee> res = (await employeeService.GetAllEmployees()).Value;
            List<GetAllEmployees_GET> getSubscribers = [];

            foreach (var r in res)
            {
                GetAllEmployees_GET getEmployee = new(r.Id, 0, r.FullName, r.PhotoId, r.DateOfBirth, r.Telegram, r.Email.email, r.Login.Number, r.Password);
                getSubscribers.Add(getEmployee);
            }

            return Results.Ok(getSubscribers);
        }
    }
}
