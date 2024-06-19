using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.CRM;
using TNS.APPLICATION.SERVICES.CRM;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.SUBSCRIBER;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.SUBSCRIBER;

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

    private static async Task<IResult> DeleteCRM(CRMService _CRMService, [FromRoute] Guid id)
    {
        var res = await _CRMService.DeleteCRM(id);
        if (res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok();
    }

    private static async Task<IResult> EditCRM(
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

    private static async Task<IResult> AddCRM(
        CRMService _CRMService, ServiceService serviceService, ServiceTypeService serviceTypeService, 
        ServiceProvidedService serviceProvidedService, SubscriberService subscriberService, AddCRM_POST editCRM)
    {
        //Result<CRM_request> sub = CRM_request.Create();

        //if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        //var result = await _CRMService.AddCRM(sub.Value);
        //if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<IResult> GetCRMById(CRMService _CRMService, 
        ServiceService serviceService, ServiceTypeService serviceTypeService, ServiceProvidedService serviceProvidedService, SubscriberService subscriberService, [FromRoute] Guid id)
    {
        var r = await _CRMService.GetByGuidCRM(id);
        if (r.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {r.Error}");

        Subscriber subscriber = subscriberService.GetByGuidSubscriber(r.Value.SubscriberId).Result.Value;
        Service service = serviceService.GetByGuidService(r.Value.ServiceId).Result.Value;
        ServiceType serviceType = serviceTypeService.GetByGuidServiceType(r.Value.ServiceTypeId).Result.Value;
        ServiceProvided serviceProvided = serviceProvidedService.GetByGuidServiceProvided(r.Value.ServiceProvidedId).Result.Value;

        GetAllCRM_GET a = new GetAllCRM_GET(
            r.Value.Id,
            subscriber.SubscriberNumber,
            subscriber.PersonalBill,
            subscriber.TypeOfEquipment,
            r.Value.CreationDate,
            r.Value.ClosingDate,
            service.Name,
            serviceProvided.Name,
            serviceType.Name,
            r.Value.Status,
            r.Value.TypeOfProblem,
            r.Value.ProblemDescription
            );

        return Results.Ok(a);
    }

    private static async Task<IResult> GetAllCRM(CRMService _CRMService,
        ServiceService serviceService, ServiceTypeService serviceTypeService, ServiceProvidedService serviceProvidedService, SubscriberService subscriberService)
    {
        var result = await _CRMService.GetAllCRM_Requests();
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        List<GetAllCRM_GET> returnValue = [];

        foreach (var r in result.Value) 
        {
            Subscriber subscriber = subscriberService.GetByGuidSubscriber(r.SubscriberId).Result.Value;
            Service service = serviceService.GetByGuidService(r.ServiceId).Result.Value;
            ServiceType serviceType = serviceTypeService.GetByGuidServiceType(r.ServiceTypeId).Result.Value;
            ServiceProvided serviceProvided = serviceProvidedService.GetByGuidServiceProvided(r.ServiceProvidedId).Result.Value;

            GetAllCRM_GET a = new GetAllCRM_GET(
                r.Id,
                subscriber.SubscriberNumber,
                subscriber.PersonalBill,
                subscriber.TypeOfEquipment,
                r.CreationDate,
                r.ClosingDate,
                service.Name,
                serviceProvided.Name,
                serviceType.Name,
                r.Status,
                r.TypeOfProblem,
                r.ProblemDescription
                );

            returnValue.Add(a);
        }

        return Results.Ok(returnValue);
    }
}
