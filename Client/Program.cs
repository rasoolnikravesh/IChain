using Microsoft.AspNetCore.SignalR.Client;



var con = new HubConnectionBuilder().WithUrl("https://localhost:7187/Test")
	.WithAutomaticReconnect()
	.Build();

con.On("ReceiveMessage", (string message) =>
{

	Console.WriteLine(message);
});

await con.StartAsync();


var stream = con.StreamAsync<DateTime>("Streaming");

await foreach (var item in stream)
{
	Console.WriteLine(item);
}






