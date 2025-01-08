namespace CookingWebApp.RecipeService
{
    public class IngriedientDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Quantity { get; set; }
        public string? Unit { get; set; }

        public IngriedientDTO() { }
        public IngriedientDTO(Ingriedient ingriedient) =>
            (Id, Name, Quantity, Unit) = (ingriedient.Id, ingriedient.Name, ingriedient.Quantity, ingriedient.Unit);
    }
}
