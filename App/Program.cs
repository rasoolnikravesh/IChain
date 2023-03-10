using App.Hubs;
using Application.Settings;
using Microsoft.AspNetCore.Builder;
using MongoDBPersistence.Settings;

var builder = WebApplication.CreateBuilder(args);

var service = new ServiceCollection();


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddUnitOfWork(new InitialSetting(builder.Configuration.GetConnectionString("mongo"), "Test"));


builder.Services.AddServices();


WebApplication app = builder.Build();



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




