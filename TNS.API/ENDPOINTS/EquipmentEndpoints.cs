using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Net;
using TNS.API.CONTRACTS.EQUIPMENT.BASESTATIONS;
using TNS.API.CONTRACTS.EQUIPMENT.EQUIPMENT;
using TNS.APPLICATION.SERVICES.EQUIPMENT;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.API.ENDPOINTS;

public static class EquipmentEndpoints
{
    public static IEndpointRouteBuilder MapEquipmentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("equipment/getAllEquipment", GetAllEquipment);
        app.MapGet("equipment/testAllEquipment", TestAllEquipment);
        app.MapGet("equipment/getEquipment/{id:guid}", GetEquipmentById);
        app.MapGet("equipment/testEquipment/{id:guid}", TestEquipment);

        app.MapGet("equipment/getAllBaseStations", GetAllBaseStations);
        app.MapGet("equipment/testAllBaseStations", TestAllBaseStations);
        app.MapGet("equipment/getBaseStation/{id:guid}", GetBaseStationById);
        app.MapGet("equipment/testBaseStations{id:guid}", TestBaseStation);

        app.MapGet("equipment/addEquipment/&{SerialNumber}&{Name}&{Frequency}&{AttenuationCoefficient}&{DTT}&{Address}&{IsWorking:bool}", AddEquipment);
        app.MapGet("equipment/addBaseStation/&{Address}&{Location}&{BaseStationName}&{S}&{Frequency}&{TypeAntenna}&{Handover}&{CommunicationProtocol}&{IsWorking:bool}", AddBaseStation);

        app.MapGet("equipment/editEquipment/{id:guid}/&{SerialNumber}&{Name}&{Frequency+79152145255}&{AttenuationCoefficient}&{DTT}&{Address}&{IsWorking:bool}", EditEquipment);
        app.MapGet("equipment/editBaseStation/{id:guid}/&{Address}&{Location}&{BaseStationName}&{S}&{Frequency}&{TypeAntenna}&{Handover}&{CommunicationProtocol}&{IsWorking:bool}", EditBaseStation);

        app.MapGet("equipment/deleteEquipment/{id:guid}", DeleteEquipment);
        app.MapGet("equipment/deleteBaseStation/{id:guid}", DeleteBaseStation);

        return app;
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> TestAllBaseStations(BaseStationService baseStationService)
    {
        var res = await baseStationService.TestAllBaseStation();
        if(res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok(res.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> TestAllEquipment(EquipmentService baseStationService)
    {
        var res = await baseStationService.TestAllEquipment();
        if (res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok(res.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteBaseStation(BaseStationService baseStationService, [FromRoute] Guid id)
    {
        var res = await baseStationService.DeleteBaseStation(id);
        if (res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteEquipment(EquipmentService baseStationService, [FromRoute] Guid id)
    {
        var res = await baseStationService.DeleteEquipment(id);
        if (res.IsFailure) return Results.BadRequest($"{res.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> EditBaseStation(
        [FromRoute] Guid id,
        [FromRoute] string Address,
        [FromRoute] string Location,
        [FromRoute] string BaseStationName,
        [FromRoute] double S,
        [FromRoute] int Frequency,
        [FromRoute] string TypeAntenna,
        [FromRoute] int Handover,
        [FromRoute] string CommunicationProtocol,
        [FromRoute] bool IsWorking, BaseStationService baseStationService, BaseStationAddressService baseStationAddressService)
    {
        Result<BaseStationAddress> bsAdd = BaseStationAddress.Create(Address, Location);
        if (bsAdd.IsFailure) return Results.BadRequest($"{bsAdd.Error}");
        await baseStationAddressService.UpdateBaseStationAddress(bsAdd.Value, baseStationService.GetByGuidBaseStation(id).Result.Value.AddressId);

        Result<BaseStation> sub = BaseStation.Create(
            baseStationService.GetByGuidBaseStation(id).Result.Value.AddressId,
            BaseStationName,
            S,
            Frequency,
            TypeAntenna,
            Handover,
            CommunicationProtocol,
            IsWorking);

        if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        var result = await baseStationService.UpdateBaseStation(sub.Value, id);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> EditEquipment(
        [FromRoute] Guid id,
        [FromRoute] string SerialNumber,
        [FromRoute] string Name,
        [FromRoute] int Frequency,
        [FromRoute] string AttenuationCoefficient,
        [FromRoute] string DTT,
        [FromRoute] string Address,
        [FromRoute] bool IsWorking, 
        EquipmentService baseStationService)
    {
        Result<Equipment> sub = Equipment.Create(
            SerialNumber,
            Name,
            Frequency,
            AttenuationCoefficient,
            DTT,
            Address,
            IsWorking);

        if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        var result = await baseStationService.UpdateEquipment(sub.Value, id);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> AddBaseStation(
        [FromRoute] string Address,
        [FromRoute] string Location,
        [FromRoute] string BaseStationName,
        [FromRoute] double S,
        [FromRoute] int Frequency,
        [FromRoute] string TypeAntenna,
        [FromRoute] int Handover,
        [FromRoute] string CommunicationProtocol,
        [FromRoute] bool IsWorking,
        BaseStationService baseStationService,
        BaseStationAddressService baseStationAddressService)
    {
        Result<BaseStationAddress> bsAdd = BaseStationAddress.Create(Address, Location);
        Result<BaseStation> sub = BaseStation.Create(
            bsAdd.Value.Id,
            BaseStationName,
            S,
            Frequency,
            TypeAntenna,
            Handover,
            CommunicationProtocol,
            IsWorking);

        if (bsAdd.IsFailure) return Results.BadRequest($"{sub.Error}");
        if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        var res = await baseStationAddressService.AddBaseStationAddress(bsAdd.Value);
        var result = await baseStationService.AddBaseStation(sub.Value);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> AddEquipment(
        [FromRoute] string SerialNumber,
        [FromRoute] string Name,
        [FromRoute] int Frequency,
        [FromRoute] string AttenuationCoefficient,
        [FromRoute] string DTT,
        [FromRoute] string Address,
        [FromRoute] bool IsWorking,
        EquipmentService baseStationService)
    {
        Result<Equipment> sub = Equipment.Create(
            SerialNumber,
            Name,
            Frequency,
            AttenuationCoefficient,
            DTT,
            Address,
            IsWorking);

        if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");

        var result = await baseStationService.AddEquipment(sub.Value);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok();
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> TestBaseStation([FromRoute] Guid id, BaseStationService baseStationService)
    {
        var result = await baseStationService.TestBaseStation(id);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok(result.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetBaseStationById([FromRoute] Guid id, BaseStationService baseStationService)
    {
        var r = await baseStationService.GetByGuidBaseStation(id);
        if (r.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {r.Error}");

        GetAllBaseStations_GET baseStation = new(
            r.Value.Id,
            r.Value.AddressId,
            r.Value.BaseStationName,
            r.Value.S,
            r.Value.Frequency,
            r.Value.TypeAntenna,
            r.Value.Handover,
            r.Value.CommunicationProtocol,
            r.Value.IsWorking
            );

        return Results.Ok(baseStation);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllBaseStations(BaseStationService baseStationService)
    {
        var result = await baseStationService.GetAllBaseStations();
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok(result.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> TestEquipment([FromRoute] Guid id, EquipmentService baseStationService)
    {
        var result = await baseStationService.TestEquipment(id);
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok(result.Value);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetEquipmentById([FromRoute] Guid id, EquipmentService baseStationService)
    {
        var r = await baseStationService.GetByGuidEquipment(id);
        if (r.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {r.Error}");

        GetAllEquipments_GET baseStation = new(
            r.Value.Id,
            r.Value.SerialNumber,
            r.Value.Name,
            r.Value.Frequency,
            r.Value.AttenuationCoefficient,
            r.Value.DTT,
            r.Value.Address,
            r.Value.IsWorking
            );

        return Results.Ok(baseStation);
    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllEquipment(EquipmentService baseStationService)
    {
        var result = await baseStationService.GetAllEquipments();
        if (result.IsFailure) return Results.BadRequest($"BadRequestBaseStation: {result.Error}");

        return Results.Ok(result.Value);
    }
}