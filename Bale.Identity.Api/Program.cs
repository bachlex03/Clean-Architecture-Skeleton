using Asp.Versioning.ApiExplorer;
using Bale.Identity.Api;
using Bale.Identity.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPresentation().AddApplication();

// Add Serilog to the builder
builder.Host.AddSerilog(builder.Configuration);


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

// Add Serilog to the request pipeline, enable request logging through http
app.UseSerilogRequestLogging();

//use error endpoint to catch exception
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
