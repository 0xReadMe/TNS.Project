﻿using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using TNS.API.CONTRACTS.SUBSCRIBERS;
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

        private static async Task<Microsoft.AspNetCore.Http.IResult> DeleteSubscriber(SubscriberService subscriberService, PersonService personService,[FromRoute] Guid id)
        {
            var result = await subscriberService.DeleteSubscriber(id);
            var result2 = await personService.DeletePerson(subscriberService.GetByGuidSubscriber(id).Result.Value.PersonId);
            if (result.IsFailure) return Results.BadRequest($"{result.Error}");
            if (result2.IsFailure) return Results.BadRequest($"{result2.Error}");
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
            person  = Person.AddSubscriberId(person.Value, sub.Value.Id);
            sub     = Subscriber.AddPersonId(sub.Value, person.Value.Id);

            if (sub.IsFailure)          return Results.BadRequest($"{sub.Error}");
            if (phone.IsFailure)        return Results.BadRequest($"{phone.Error}");
            if (email.IsFailure)        return Results.BadRequest($"{email.Error}");
            if (passport.IsFailure)     return Results.BadRequest($"{passport.Error}");
            if (person.IsFailure)       return Results.BadRequest($"{person.Error}");

            var result                  = await subscriberService.UpdateSubscriber(sub.Value, id);
            var resultPerson            = await personService.UpdatePerson(person.Value, sub.Value.PersonId);

            if (result.IsFailure)       return Results.BadRequest($"BadRequestSubscriber: {result.Error}");
            if (resultPerson.IsFailure) return Results.BadRequest($"BadRequestPerson: {resultPerson.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> AddSubscriber([FromBody] AddSubscriber_POST r, SubscriberService subscriberService, PersonService personService)
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
            person  = Person.AddSubscriberId(person.Value, sub.Value.Id);
            sub     = Subscriber.AddPersonId(sub.Value, person.Value.Id);

            if (sub.IsFailure)          return Results.BadRequest($"BadRequest - {sub.Error}");
            if (phone.IsFailure)        return Results.BadRequest($"BadRequest - {phone.Error}");
            if (email.IsFailure)        return Results.BadRequest($"BadRequest - {email.Error}");
            if (passport.IsFailure)     return Results.BadRequest($"BadRequest - {passport.Error}");
            if (person.IsFailure)       return Results.BadRequest($"BadRequest - {person.Error}");

            var result                  = await subscriberService.AddSubscriber(sub.Value);
            var resultPerson            = await personService.AddPerson(person.Value);

            if (result.IsFailure)       return Results.BadRequest($"BadRequestSubscriber - {result.Error}");
            if (resultPerson.IsFailure) return Results.BadRequest($"BadRequestPerson - {result.Error}");

            return Results.Ok();
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetSubscriberById(PersonService personService, SubscriberService subscriberService, [FromRoute] Guid id)
        {
            var r = (await subscriberService.GetByGuidSubscriber(id)).Value;
            var r2 = (await personService.GetByGuidPerson(r.PersonId)).Value;

            GetSubscriber_GET getSubscriber = new(
                r.Id,
                r.SubscriberNumber,
                r.ContractNumber,
                r.ContractType,
                r.ReasonForTerminationOfContract,
                r.PersonalBill,
                r.Services,
                r.DateOfContractConclusion,
                r.DateOfTerminationOfTheContract,
                r.TypeOfEquipment,
                r2.Id,
                r2.FirstName,
                r2.MiddleName,
                r2.LastName,
                r2.Gender,
                r2.DOB,
                r2.PhoneNumber.Number,
                r2.Email.email,
                r2.Passport.DivisionCode,
                r2.Passport.IssuedBy,
                r2.Passport.Series,
                r2.Passport.Number,
                r2.Passport.ResidenceAddress,
                r2.Passport.ResidentialAddress,
                r2.Passport.DateOfIssueOfPassport);

            return Results.Ok(getSubscriber);
        }

        private static async Task<Microsoft.AspNetCore.Http.IResult> GetAllSubscribers(PersonService personService, SubscriberService subscriberService)
        {
            var r = (await subscriberService.GetAllSubscribers()).Value;
            List<GetSubscriber_GET> getSubscribers = [];

            for(int i = 0; i < r.Count; i++)
            {
                var r2 = personService.GetByGuidPerson(r[i].PersonId).Result.Value;

                GetSubscriber_GET getSubscriber = new(
                    r[i].Id,
                    r[i].SubscriberNumber,
                    r[i].ContractNumber,
                    r[i].ContractType,
                    r[i].ReasonForTerminationOfContract,
                    r[i].PersonalBill,
                    r[i].Services,
                    r[i].DateOfContractConclusion,
                    r[i].DateOfTerminationOfTheContract,
                    r[i].TypeOfEquipment,
                    r2.Id,
                    r2.FirstName,
                    r2.MiddleName,
                    r2.LastName,
                    r2.Gender,
                    r2.DOB,
                    r2.PhoneNumber.Number,
                    r2.Email.email,
                    r2.Passport.DivisionCode,
                    r2.Passport.IssuedBy,
                    r2.Passport.Series,
                    r2.Passport.Number,
                    r2.Passport.ResidenceAddress,
                    r2.Passport.ResidentialAddress,
                    r2.Passport.DateOfIssueOfPassport);

                getSubscribers.Add(getSubscriber);
            }

            return Results.Ok(getSubscribers);
        }
    }
}