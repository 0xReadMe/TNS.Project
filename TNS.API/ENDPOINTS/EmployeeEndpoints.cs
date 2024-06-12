
using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.EMPLOYEES;
using TNS.APPLICATION.SERVICES;

namespace TNS.API.ENDPOINTS
{
    public static class EmployeeEndpoints
    {
        public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("employee/getAll", GetAllEmployees);
            app.MapGet("employee/get/{id}", GetEmployeeById);

            app.MapPost("employee/login", Login);
            app.MapPost("employee/add", AddEmployee);

            app.MapPut("employee/edit", EditEmployee);

            app.MapDelete("employee/delete", DeleteEmployee);

            return app;
        }

        private static async Task<IResult> AddEmployee(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> DeleteEmployee(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> EditEmployee(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> Login(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> GetEmployeeById(HttpContext context, [FromRoute] Guid id)
        {
            return Results.Ok();
        }

        private static async Task<IResult> GetAllEmployees(EmployeeService employeeService, HttpContext context)
        {
            //var employees = await employeeService.GetAll();

            //var responce = employees
            //    .Select(emp => new GetEmployees(
            //        emp.Id, 
            //        emp.PositionId, 
            //        emp.FullName, 
            //        emp.PhotoId, 
            //        emp.Login.Number, 
            //        emp.PasswordHash)
            //    );

            return Results.Ok();
        }
    }
}
