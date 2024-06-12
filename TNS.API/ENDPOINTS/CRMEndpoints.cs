
namespace TNS.API.ENDPOINTS;

public static class CRMEndpoints
{
    public static IEndpointRouteBuilder MapCRMEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("CRM/getAll", GetAllCRM);
        app.MapGet("CRM/get/{id}", GetCRMById);
        app.MapGet("CRM/testEquipment", TestEquipment);

        app.MapPost("CRM/add", AddCRM);

        app.MapPut("CRM/edit", EditCRM);

        app.MapDelete("CRM/delete", DeleteCRM);

        return app;
    }

    private static async Task<IResult> DeleteCRM(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> EditCRM(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> AddCRM(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> TestEquipment(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetCRMById(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetAllCRM(HttpContext context)
    {
        return Results.Ok();
    }
}
