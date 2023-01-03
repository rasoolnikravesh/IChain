using App.Hubs;
using Microsoft.AspNetCore.SignalR;
using NetworkBase;

namespace App.Services;

public class TransactionService : ITransactionService
{
	public IHubContext<TransactionHub> Context { get; }

	public TransactionService(IHubContext<TransactionHub> context)
	{
		Context = context;

	}

	public async Task BroadCast(string message, CancellationToken cancellationToken)
	{
		await Context.Clients.All.SendAsync("ReceiveTransaction", message, cancellationToken: cancellationToken);

	}


}