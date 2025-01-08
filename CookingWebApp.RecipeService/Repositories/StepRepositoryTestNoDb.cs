namespace CookingWebApp.RecipeService.Repositories
{
    public interface IStepRepository
    {
        Task<Step[]> GetSteps(int recipeId);
    }

    public class StepRepositoryTestNoDb : IStepRepository
    {
        public async Task<Step[]> GetSteps(int recipeId)
        {
            return new List<Step>
        {
            new Step { RecipeId = recipeId, Id = 1, Description = "Step 1" },
            new Step { RecipeId = recipeId, Id = 2, Description = "Step 2" }
        }.ToArray();
        }
    }
}



