using CookingWebApp.RecipeService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookingWebApp.RecipeService.Endpoints
{
    public static class RecipeEndpoints
    {
        public static void MapRecipeEndpoints(WebApplication app)
        {
            RouteGroupBuilder recipeItems = app.MapGroup("/recipe");
            recipeItems.MapGet("/", GetRecipes).WithName("GetRecipes");
            recipeItems.MapGet("/{id}", GetRecipe).WithName("GetRecipe");
            recipeItems.MapPost("/", CreateRecipe).WithName("CreateRecipe");
            //recipeitems.MapPut("/{id}", UpdateRecipe).WithName("UpdateRecipe");
            //recipeitems.MapDelete("/{id}", DeleteRecipe).WithName("DeleteRecipe");
        }

        private static async Task<IResult> GetRecipes([FromServices] IRecipeRepository recipeRepository)
        {
            return Results.Ok(await recipeRepository.GetRecipes());
        }

        private static async Task<IResult> GetRecipe([FromServices] IRecipeRepository recipeRepository, int id)
        {
            return Results.Ok(await recipeRepository.GetRecipe(id));
        }

        private static async Task<IResult> CreateRecipe(LinkGenerator linker, [FromServices] IRecipeRepository recipeRepository, Recipe recipe)
        {
            return Results.Created($"{linker.GetPathByName("GetRecipe", values: null)}", await recipeRepository.CreateRecipe(recipe));
        }
    }
}

