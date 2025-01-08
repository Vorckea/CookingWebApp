var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CookingWebApp_ApiService>("apiservice");

var recipeService = builder.AddProject<Projects.CookingWebApp_RecipeService>("recipeservice");

builder.AddProject<Projects.CookingWebApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(recipeService)
    .WaitFor(apiService)
    .WaitFor(recipeService);

builder.Build().Run();
