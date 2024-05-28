using TNS.API.ENDPOINTS;

namespace TNS.API.EXTENSIONS
{
    public static class ApiExtensions
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapEmployeeEndpoints();
        }
    }
}
