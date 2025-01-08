namespace CookingWebApp.RecipeService
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public StepDTO() { }
        public StepDTO(Step step) =>
            (Id, Description) = (step.Id, step.Description);
    }
}
