using DogGraph.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationConventions();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
