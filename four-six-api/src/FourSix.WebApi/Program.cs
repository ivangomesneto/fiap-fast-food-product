using FourSix.Controllers.Gateways.DataAccess;
using FourSix.WebApi.Modules;
using FourSix.WebApi.Modules.Commons;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAdapters();
builder.Services.AddSQLServer();
builder.Services.AddUseCases();
builder.Services.AddCustomControllers();
builder.Services.AddCustomCors();
builder.Services.AddSwaggerConfig();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<Context>();
    dataContext.Database.Migrate();
}

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

app.AddRoutesMaps();

app.MapControllers();

app.Run();

//public class validEnumConverter : System.Text.Json.Serialization.JsonConverter
//{
//    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//    {
//        if (!Enum.IsDefined(objectType, reader.Value))
//        {
//            throw new ArgumentException("Invalid enum value");
//        }

//        return base.ReadJson(reader, objectType, existingValue, serializer);
//    }
//}