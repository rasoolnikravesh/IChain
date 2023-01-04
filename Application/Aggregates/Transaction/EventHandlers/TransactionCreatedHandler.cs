using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aggregates.Transaction.Events;
using Microsoft.AspNetCore.SignalR.Client;

namespace Application.Aggregates.Transaction.EventHandlers;

public class TransactionCreatedHandler : MediatR.INotificationHandler<TransactionCreated>
{

	private readonly HubConnection con;

	public TransactionCreatedHandler()
	{
		con = new HubConnectionBuilder().WithUrl("https://localhost:5001/Transaction")
			.WithAutomaticReconnect()
			.Build();
	}
	public async Task Handle(TransactionCreated notification, CancellationToken cancellationToken)
	{
		


		con.Closed += Con_Closed;

		con.On("Test", (string s) =>
		{
			Console.WriteLine(s);
		});

		await con.StartAsync(cancellationToken).WaitAsync(cancellationToken);

		await con.SendAsync("ReceiveTransaction", notification, cancellationToken);

		//await con.SendAsync("stream", arg1: clientStreamData(), cancellationToken);
	}

	public async IAsyncEnumerable<DateTime> clientStreamData()
	{
		for (var i = 0; i < 500; i++)
		{
			var data = DateTime.Now;
			await Task.Delay(300);

			yield return data;
		}
		//After the for loop has completed and the local function exits the stream completion will be sent.
	}

	private Task Con_Closed(Exception? arg)
	{

		Console.WriteLine("Closed");

		return Task.CompletedTask;
	}
}