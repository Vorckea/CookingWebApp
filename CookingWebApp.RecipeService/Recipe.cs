namespace CookingWebApp.RecipeService
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Ingriedient> Ingredients { get; set; } = new List<Ingriedient>();
        public List<Step> Steps { get; set; } = new List<Step>();
    }

    public class Ingriedient
    {
        public int RecipeId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Quantity { get; set; }
        public string? Unit { get; set; }
    }

    public class Step
    {
        public int RecipeId { get; set; }
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
