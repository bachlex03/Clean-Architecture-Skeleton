using Asp.Versioning.ApiExplorer;
using Bale.Identity.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Get the API version descriptions
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

        // Add the Swagger endpoints for each API version
        foreach (var description in descriptions)
        {
            // Create the Swagger endpoint URL
            string url = $"/swagger/{description.GroupName}/swagger.json";
            // Create the Swagger endpoint name
            string name = description.GroupName.ToUpperInvariant();

            // Add the Swagger endpoint to the Swagger UI
            options.SwaggerEndpoint(url, name);
        }
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
