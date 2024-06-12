using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.SUBSCRIBERS;
using TNS.APPLICATION.SERVICES;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.CORE.VO;

namespace TNS.API.ENDPOINTS
{
    public static class SubscriberEndpoints
    {
        public static IEndpointRouteBuilder MapSubscriberEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("subscriber/getAll", GetAllSubscribers);
            app.MapGet("subscriber/get/{id:guid}", GetSubscriberById);

            app.MapPost("subscriber/add", AddSubscriber);

            app.MapPut("subscriber/edit/{id:guid}", EditSubscriber);

            app.MapDelete("subscriber/delete/{id:guid}", DeleteSubscriber);

            return app;
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteSubscriber(SubscriberService subscriberService,[FromRoute] Guid id)
        {
            var result = await subscriberService.DeleteSubscriber(id);
            if (result.IsFailure) return Results.BadRequest($"{result.Error}");
            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> EditSubscriber(
            [FromRoute] Guid id, [FromBody] EditSubscriber_PUT r, SubscriberService subscriberService, PersonService personService)
        {
            Result<Subscriber> sub = Subscriber.Create(r.DateOfContractConclusion,
                                               r.DateOfTerminationOfTheContract,
                                               r.ReasonForTerminationOfContract,
                                               r.TypeOfEquipment,
                                               r.Services,
                                               r.ContractType,
                                               r.PersonalBill);

            Result<PhoneNumber> phone = PhoneNumber.Create(r.PhoneNumber);

            Result<Email> email = Email.Create(r.Email);

            Result<Passport> passport = Passport.Create(r.DivisionCode,
                                                r.IssuedBy,
                                                r.Series,
                                                r.Number,
                                                r.ResidenceAddress,
                                                r.ResidentialAddress,
                                                r.DateOfIssueOfPassport);

            Result<Person> person = Person.Create(r.FirstName, r.MiddleName, r.LastName, r.Gender, r.DOB, phone.Value, email.Value, passport.Value);
            person = Person.AddSubscriberId(person.Value, sub.Value.Id);

            if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");
            if (phone.IsFailure) return Results.BadRequest($"{phone.Error}");
            if (email.IsFailure) return Results.BadRequest($"{email.Error}");
            if (passport.IsFailure) return Results.BadRequest($"{passport.Error}");
            if (person.IsFailure) return Results.BadRequest($"{person.Error}");

            var result = await subscriberService.UpdateSubscriber(sub.Value, id);
            //var resultPerson = await personService.UpdatePerson(person.Value, id);

            if (result.IsFailure) return Results.BadRequest($"BadRequestSubscriber: {result.Error}");
            //if (resultPerson.IsFailure) return Results.BadRequest($"BadRequestPerson: {result.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> AddSubscriber(
            [FromBody] AddSubscriber_POST r, SubscriberService subscriberService, PersonService personService)
        {
            Result<Subscriber> sub = Subscriber.Create(r.DateOfContractConclusion,
                                               r.DateOfTerminationOfTheContract,
                                               r.ReasonForTerminationOfContract,
                                               r.TypeOfEquipment,
                                               r.Services,
                                               r.ContractType,
                                               r.PersonalBill);

            Result<PhoneNumber> phone = PhoneNumber.Create(r.PhoneNumber);

            Result<Email> email = Email.Create(r.Email);

            Result<Passport> passport = Passport.Create(r.DivisionCode,
                                                r.IssuedBy,
                                                r.Series,
                                                r.Number,
                                                r.ResidenceAddress,
                                                r.ResidentialAddress,
                                                r.DateOfIssueOfPassport);

            Result<Person> person = Person.Create(r.FirstName, r.MiddleName, r.LastName, r.Gender, r.DOB, phone.Value, email.Value, passport.Value);
            person = Person.AddSubscriberId(person.Value, sub.Value.Id);

            if (sub.IsFailure) return Results.BadRequest($"{sub.Error}");
            if (phone.IsFailure) return Results.BadRequest($"{phone.Error}");
            if (email.IsFailure) return Results.BadRequest($"{email.Error}");
            if (passport.IsFailure) return Results.BadRequest($"{passport.Error}");
            if (person.IsFailure) return Results.BadRequest($"{person.Error}");

            var result = await subscriberService.AddSubscriber(sub.Value);
            //var resultPerson = await personService.AddPerson(person.Value);

            if (result.IsFailure) return Results.BadRequest($"BadRequestSubscriber: {result.Error}");
            //if (resultPerson.IsFailure) return Results.BadRequest($"BadRequestPerson: {result.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetSubscriberById(
            SubscriberService subscriberService, [FromRoute] Guid id)
        {
            var result = await subscriberService.GetByGuidSubscriber(id);
            return Results.Ok(result.Value);
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllSubscribers(SubscriberService subscriberService)
        {
            var result = await subscriberService.GetAllSubscribers();
            return Results.Ok(result.Value);
        }
    }
}
