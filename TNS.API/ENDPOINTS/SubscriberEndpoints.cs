using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace TNS.API.ENDPOINTS
{
    public static class SubscriberEndpoints
    {
        public static IEndpointRouteBuilder MapSubscriberEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("subscriber/getAll", GetAllSubscribers);
            app.MapGet("subscriber/get/{id}", GetSubscriberById);

            app.MapPost("subscriber/add", AddSubscriber);

            app.MapPut("subscriber/edit", EditSubscriber);

            app.MapDelete("subscriber/delete", DeleteSubscriber);

            return app;
        }

        private static async Task<IResult> DeleteSubscriber(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> EditSubscriber(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> AddSubscriber(HttpContext context)
        {
            return Results.Ok();
        }

        private static async Task<IResult> GetSubscriberById(HttpContext context, [FromRoute] Guid id)
        {
            return Results.Ok();
        }

        private static async Task<IResult> GetAllSubscribers(HttpContext context)
        {
            return Results.Ok();
        }
    }
}
