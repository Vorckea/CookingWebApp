using CookingWebApp.RecipeService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CookingWebApp.RecipeService.Endpoints
{
    public static class IngredientEndpoints
    {
        public static void MapIngredientEndpoints(WebApplication app)
        {
            RouteGroupBuilder ingredientItems = app.MapGroup("/recipe/{recipeId}/ingredient");
            ingredientItems.MapGet("/", GetIngredients).WithName("GetIngredients");
            //ingredientitems.MapGet("/{id}", GetIngredient).WithName("GetIngredient");
            //ingredientitems.MapPost("/", CreateIngredient).WithName("CreateIngredient");
            //ingredientitems.MapPut("/{id}", UpdateIngredient).WithName("UpdateIngredient");
            //ingredientitems.MapDelete("/{id}", DeleteIngredient).WithName("DeleteIngredient");
        }

        private static async Task<IResult> GetIngredients([FromServices] IIngredientRepository ingredientRepository, int recipeId)
        {
            var ingredients = await Task.Run(() => new List<Ingriedient>
            {
                new Ingriedient { RecipeId = recipeId, Id = 1, Name = "Ingriedient 1", Quantity = 1, Unit = "Unit 1" },
                new Ingriedient { RecipeId = recipeId, Id = 2, Name = "Ingriedient 2", Quantity = 2, Unit = "Unit 2" }
            });
            return Results.Ok(await ingredientRepository.GetIngredients(recipeId));
        }
    }
}



