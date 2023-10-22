using Microsoft.OpenApi.Models;
using Products.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();

builder.Services.AddRepositories();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "Products API", Version = "v1.0.0" });
});
builder.Services.AddControllers();
var app = builder.Build();


app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Api");
});

app.Run();