
using TNS.API.CONTRACTS.EMPLOYEES;
using TNS.APPLICATION.SERVICES;

namespace TNS.API.ENDPOINTS
{
    public static class EmployeeEndpoints
    {
        public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("employees", GetAll);

            return app;
        }

        private static async Task<IResult> GetAll(EmployeeService employeeService, HttpContext context)
        {

            var employees = await employeeService.GetAll();

            var responce = employees
                .Select(emp => new GetEmployees(
                    emp.Id, 
                    emp.PositionId, 
                    emp.FullName, 
                    emp.PhotoId, 
                    emp.Login.Number, 
                    emp.PasswordHash)
                );

            return Results.Ok(responce);
        }
    }
}
