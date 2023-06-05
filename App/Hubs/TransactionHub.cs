using Application.Aggregates.Transaction.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace App.Hubs;

public class TransactionHub : Hub
{
	public IMediator Mediator { get; }

	public TransactionHub(IMediator mediator)
	{
		Mediator = mediator;
	}

	public async Task ReceiveTransaction(TransactionCreated transaction)
	{

		await Clients.All.SendAsync("Test", "Hello");



		await Mediator.Publish(new TransactionReceived()
		{
			Created = transaction.Created,
			Data = transaction.Data,
			From = transaction.From,
			Id = transaction.Id,
			To = transaction.To,

		});
	}


	public async Task Stream(IAsyncEnumerable<DateTime> stream)
	{
		await foreach (var s in stream)
		{
			Console.WriteLine(s);

		}
	}


}