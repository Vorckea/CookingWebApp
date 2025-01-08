namespace CookingWebApp.RecipeService.Repositories
{
    public interface IRecipeRepository
    {
        Task<RecipeItemDTO[]> GetRecipes();
        Task<RecipeItemDTO> GetRecipe(int id);
        Task<Recipe> CreateRecipe(Recipe recipe);
    }

    public class RecipeRepositoryTestNoDb : IRecipeRepository
    {
        public async Task<RecipeItemDTO[]> GetRecipes()
        {
            return new List<Recipe>
        {
            new Recipe { Id = 1, Name = "Recipe 1", Description = "Description 1" },
            new Recipe { Id = 2, Name = "Recipe 2", Description = "Description 2" }
        }.Select(recipeItem => new RecipeItemDTO(recipeItem)).ToArray();
        }

        public async Task<RecipeItemDTO> GetRecipe(int id)
        {
            return new RecipeItemDTO(new Recipe
            {
                Id = id,
                Name = $"Recipe {id}",
                Description = $"Description {id}"
            });
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            recipe.Id = 3;
            return recipe;
        }
    }
}
