using App.Hubs;
using App.Services;
using Application.Services;
using Application.Settings;
using Microsoft.AspNetCore.Builder;
using MongoDBPersistence.Settings;
using NetworkBase;

var builder = WebApplication.CreateBuilder(args);

var service = new ServiceCollection();


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddUnitOfWork(new InitialSetting(builder.Configuration.GetConnectionString("mongo"), "Test"));

builder.Services.AddSingleton<IStartService, StartService>();
builder.Services.AddSingleton<IAppService, AppService>();
builder.Services.AddSingleton<IClientService, ClientService>();

	builder.Services.AddServices();


WebApplication app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();

var startService = scope.ServiceProvider.GetRequiredService<IStartService>();

await startService.StartAsync();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapHub<TestHub>("/Test");
app.MapHub<TransactionHub>("/Transaction");

app.MapControllers();

await app.RunAsync();




