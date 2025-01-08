namespace CookingWebApp.RecipeService
{
    public class RecipeItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public RecipeItemDTO() { }
        public RecipeItemDTO(Recipe recipeItem) =>
            (Id, Name, Description) = (recipeItem.Id, recipeItem.Name, recipeItem.Description);
    }
}
