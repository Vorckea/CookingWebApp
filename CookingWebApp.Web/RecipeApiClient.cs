namespace CookingWebApp.Web
{
    public class RecipeApiClient(HttpClient httpClient)
    {
        public async Task<Recipe[]> GetRecipesAsync(int maxItems = 10, CancellationToken cancellationToken = default)
        {
            List<Recipe>? recipes = null;

            await foreach (var recipe in httpClient.GetFromJsonAsAsyncEnumerable<Recipe>("/recipe", cancellationToken))
            {
                if (recipes?.Count >= maxItems)
                {
                    break;
                }
                if (recipe is not null)
                {
                    recipes ??= [];
                    recipes.Add(recipe);
                }
            }

            return recipes?.ToArray() ?? [];
        }

        public async Task<Recipe> GetRecipeAsync(int recipeId, CancellationToken cancellationToken = default)
        {
            Recipe? recipe = await httpClient.GetFromJsonAsync<Recipe>($"/recipe/{recipeId}", cancellationToken);
            return recipe ?? new Recipe();
        }

        public async Task<Recipe> PostRecipeAsync(Recipe recipe, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage? response = await httpClient.PostAsJsonAsync("/recipe", recipe, cancellationToken);
            Recipe? createdRecipe = await response.Content.ReadFromJsonAsync<Recipe>(cancellationToken: cancellationToken);
            return createdRecipe ?? new Recipe();
        }

        public async Task<Ingredient[]> GetIngredientAsync(int recipeId, int maxItems = 10, CancellationToken cancellationToken = default)
        {
            List<Ingredient>? ingriedients = null;

            await foreach (Ingredient? ingriedient in httpClient.GetFromJsonAsAsyncEnumerable<Ingredient>($"/recipe/{recipeId}/ingredient", cancellationToken))
            {
                if (ingriedients?.Count >= maxItems)
                {
                    break;
                }
                if (ingriedient is not null)
                {
                    ingriedients ??= [];
                    ingriedients.Add(ingriedient);
                }
            }

            return ingriedients?.ToArray() ?? [];
        }
    }

    public record Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();
    }

    public record Ingredient
    {
        public string? Name { get; set; }
        public float Quantity { get; set; }
        public string? Unit { get; set; }
    }

    public record Step
    {
        public string? Description { get; set; }
    }
}
