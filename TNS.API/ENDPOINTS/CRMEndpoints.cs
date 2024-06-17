using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.CRM;
using TNS.APPLICATION.SERVICES.CRM;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;

namespace TNS.API.ENDPOINTS;

public static class CRMEndpoints
{
    public static IEndpointRouteBuilder MapCRMEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("CRM/getAll", GetAllCRM);
        app.MapGet("CRM/get/{id:guid}", GetCRMById);
        app.MapGet("CRM/get/service/{id:guid}", GetServiceById);
        app.MapGet("CRM/get/serviceProvided/{id:guid}", GetServiceProvidedById);
        app.MapGet("CRM/get/serviceType/{id:guid}", GetServiceTypeById);
        app.MapGet("CRM/testEquipment", TestEquipment);

        app.MapPost("CRM/add", AddCRM);

        app.MapPut("CRM/edit/{id:guid}", EditCRM);

        app.MapDelete("CRM/delete/{id:guid}", DeleteCRM);

        return app;
    }

    private static async Task GetServiceTypeById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetServiceProvidedById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetServiceById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> TestEquipment(CRMService _CRMService) => Results.Ok(_CRMService.TestCRMEquipment().Result);

    private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteCRM(CRMService _CRMService, [FromRoute] Guid id)
    {
        var res = await _CRMService.DeleteCRM(id);
        if (res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> EditCRM(
        CRMService _CRMService, [FromRoute] Guid id, ServiceService serviceService, 
        ServiceTypeService serviceTypeService, ServiceProvidedService serviceProvidedService, SubscriberService subscriberService,
        EditCRM_PUT editCRM)
    {
        //Result<CRM_request> sub = CRM_request.Create();

        //if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        //var result = await _CRMService.UpdateCRM(sub.Value, id);
        //if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> AddCRM(
        CRMService _CRMService, ServiceService serviceService, ServiceTypeService serviceTypeService, 
        ServiceProvidedService serviceProvidedService, SubscriberService subscriberService, AddCRM_POST editCRM)
    {
        //Result<CRM_request> sub = CRM_request.Create();

        //if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        //var result = await _CRMService.AddCRM(sub.Value);
        //if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetCRMById(CRMService _CRMService, [FromRoute] Guid id)
    {
        var r = await _CRMService.GetByGuidCRM(id);
        if (r.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {r.Error}");

        //GetAllCRM_GET crm = new();

        return Results.Ok(r.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllCRM(CRMService _CRMService)
    {
        var result = await _CRMService.GetAllCRM_Requests();
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok(result.Value);
    }
}
