using System.Reflection;
using App.Hubs;
using Application.Aggregates.Transaction.Commands;
using Application.Settings;
using MediatR;
using MongoDBPersistence.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddUnitOfWork(new InitialSetting(builder.Configuration.GetConnectionString("mongo"), "Test"));


builder.Services.AddServices();


WebApplication app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<TestHub>("/Test");


app.MapControllers();

app.Run();
