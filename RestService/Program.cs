using RestMessages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

app.MapPost("/greet", (HelloRequest request) =>
{
    return new HelloResponse() { Message = "Hello " + request.Name };
});

app.MapPost("/greet_complex", (ComplexRequest request) =>
{
    return new SimpleResponse() { Message = "ok" };
});

app.MapGet("/greet", () =>
{
    return 1;
});

app.Run();
