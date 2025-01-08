using CookingWebApp.RecipeService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookingWebApp.RecipeService.Endpoints
{
    public static class StepEndpoints
    {
        public static void MapStepEndpoints(WebApplication app)
        {
            RouteGroupBuilder stepItems = app.MapGroup("/recipe/{recipeId}/step");
            stepItems.MapGet("/", GetSteps).WithName("GetSteps");
            //stepitems.MapGet("/{id}", GetStep).WithName("GetStep");
            //stepitems.MapPost("/", CreateStep).WithName("CreateStep");
            //stepitems.MapPut("/{id}", UpdateStep).WithName("UpdateStep");
            //stepitems.MapDelete("/{id}", DeleteStep).WithName("DeleteStep");
        }

        private static async Task<IResult> GetSteps([FromServices] IStepRepository stepRepository, int recipeId)
        {
            return Results.Ok(await stepRepository.GetSteps(recipeId));
        }
    }
}

