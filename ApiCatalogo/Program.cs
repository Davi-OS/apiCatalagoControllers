using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// corta o ciclo de referencia dos objetos
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions
        .ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string myStringConnection = builder.Configuration.GetConnectionString("Azure");
builder.Services.AddDbContext<ApiCatalogoContext>(options =>
options.UseMySql(myStringConnection, ServerVersion.AutoDetect(myStringConnection)));
var app = builder.Build();




    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
