using System.Reflection;
using Application.Settings;
using MediatR;
using Network.Grpc.Services;
using Network.Services;
using Persistence.Mongo.Settings;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddScoped<INodeClientService, NodeClientService>();

var connectionString = builder.Configuration["DatabaseSettings:ConnectionStrings"];
var database = builder.Configuration["DatabaseSettings:DataBaseName"];
builder.Services.AddUnitOfWork(new InitialSetting(connectionString!, database!));


WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
