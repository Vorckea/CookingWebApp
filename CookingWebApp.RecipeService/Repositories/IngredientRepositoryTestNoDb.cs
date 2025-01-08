namespace CookingWebApp.RecipeService.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingriedient[]> GetIngredients(int recipeId);
    }

    public class IngredientRepositoryTestNoDb : IIngredientRepository
    {
        public async Task<Ingriedient[]> GetIngredients(int recipeId)
        {
            return new List<Ingriedient>
        {
            new Ingriedient { RecipeId = recipeId, Id = 1, Name = "Ingriedient 1", Quantity = 1, Unit = "Unit 1" },
            new Ingriedient { RecipeId = recipeId, Id = 2, Name = "Ingriedient 2", Quantity = 2, Unit = "Unit 2" }
        }.ToArray();
        }
    }
}



