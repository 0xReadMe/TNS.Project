using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace TNS.API.ENDPOINTS;

public static class EquipmentEndpoints
{
    public static IEndpointRouteBuilder MapEquipmentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("equipment/getAllEquipment", GetAllEquipment);
        app.MapGet("equipment/getEquipment/{id}", GetEquipmentById);
        app.MapGet("equipment/testEquipment", TestEquipment);

        app.MapGet("equipment/getAllBaseStations", GetAllBaseStations);
        app.MapGet("equipment/getBaseStation/{id}", GetBaseStationById);
        app.MapGet("equipment/testBaseStations", TestBaseStation);

        app.MapPost("equipment/addEquipment", AddEquipment);
        app.MapPost("equipment/addBaseStation", AddBaseStation);

        app.MapPut("equipment/editEquipment", EditEquipment);
        app.MapPut("equipment/editBaseStation", EditBaseStation);

        app.MapDelete("equipment/deleteEquipment", DeleteEquipment);
        app.MapDelete("equipment/deleteBaseStation", DeleteBaseStation);

        return app;
    }

    private static async Task<IResult> DeleteBaseStation(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> DeleteEquipment(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> EditBaseStation(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> EditEquipment(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> AddBaseStation(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> AddEquipment(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> TestBaseStation(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetBaseStationById(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetAllBaseStations(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> TestEquipment(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetEquipmentById(HttpContext context)
    {
        return Results.Ok();
    }

    private static async Task<IResult> GetAllEquipment(HttpContext context)
    {
        return Results.Ok();
    }
}
