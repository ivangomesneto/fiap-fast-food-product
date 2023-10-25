using FourSix.WebApi.Modules;
using FourSix.WebApi.Modules.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSQLServer();
builder.Services.AddUseCases();
builder.Services.AddCustomControllers();
builder.Services.AddCustomCors();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
                    options =>
                    {
                        var swaggerEndpoint = $"/swagger/v1/swagger.json";
                        options.SwaggerEndpoint(swaggerEndpoint, "v1");
                    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
