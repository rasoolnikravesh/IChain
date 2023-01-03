
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;

namespace App.Hubs;

public class TestHub : Hub
{

	public async Task BroadcastMessage(string message)
	{
		await Clients.All.SendAsync("ReceiveMessage", message);

		
	}
	

	public async IAsyncEnumerable<DateTime> Streaming([EnumeratorCancellation] CancellationToken cancellationToken)
	{
		while (true)
		{
			yield return DateTime.UtcNow;
			await Task.Delay(1000, cancellationToken);
		}
	}

	
	public override async Task OnConnectedAsync()
	{
		Console.WriteLine("test");

		await BroadcastMessage("Hello");

		await base.OnConnectedAsync();
	}

	public override async Task OnDisconnectedAsync(Exception? exception)
	{
		await base.OnDisconnectedAsync(exception);
	}


}