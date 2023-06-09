using Application.Settings;
using Network.Grpc.Services;
using Network.Services;
using Persistence.Mongo.Settings;
using Validator.Services;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(op =>
{
	op.EnableDetailedErrors = true;
});


builder.Services.AddScoped<INodeClientService, NodeClientService>();
builder.Services.AddServices();
builder.Services.AddUnitOfWork(new InitialSetting("mongodb://localhost:27017", "BlockChain"));

WebApplication app = builder.Build();


app.MapGrpcService<NodeServerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
