using Movielens.API.EndpointHandlers;
using Movielens.Application.Configuration;
using Movielens.Data.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddHealthChecks();
builder.Services
    .AddEndpointsApiExplorer()
    .AddProblemDetails()
    .AddLocalization()
    .AddSwaggerGen(options =>
    {
        options.EnableAnnotations();
        options.SupportNonNullableReferenceTypes();
    });

// Add Application services
builder.Services.ConfigureApplication();
builder.Services.ConfigureData();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseReDoc(c =>
{
    c.RoutePrefix = "docs";
    c.SpecUrl = "/swagger/v1/swagger.json";
});

// Log all Request and Responses
app.UseHttpLogging();

// Redirect to HTTPS
app.UseHttpsRedirection();

// Map Endpoints
app.MapHealthChecks("/health");
app.MapGroup("/movies").MapMovies();

// Configure Exception handlers and Status codes
app
    .UseExceptionHandler()
    .UseStatusCodePages();

// Run the API
app.Run();