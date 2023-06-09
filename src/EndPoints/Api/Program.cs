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

builder.Services.AddUnitOfWork(new InitialSetting(
	"mongodb://localhost:27017", "BlockChain"));


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
