using CookingWebApp.RecipeService.Endpoints;
using CookingWebApp.RecipeService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

if (builder.Environment.IsDevelopment())
{
    RegisterRepositoriesTestNoDb(builder);
}

if (builder.Environment.IsProduction())
{
    //TODO Create a database and use the real repository
}

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

RegisterEndpoints(app);

app.Run();

static void RegisterEndpoints(WebApplication app)
{
    RecipeEndpoints.MapRecipeEndpoints(app);
    IngredientEndpoints.MapIngredientEndpoints(app);
    StepEndpoints.MapStepEndpoints(app);
}

static void RegisterRepositoriesTestNoDb(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IRecipeRepository, RecipeRepositoryTestNoDb>();
    builder.Services.AddTransient<IStepRepository, StepRepositoryTestNoDb>();
    builder.Services.AddTransient<IIngredientRepository, IngredientRepositoryTestNoDb>();
}