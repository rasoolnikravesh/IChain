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

	public TransactionCreatedHandler()
	{

	}
	public async Task Handle(TransactionCreated notification, CancellationToken cancellationToken)
	{

		var con = new HubConnectionBuilder().WithUrl("https://localhost:7187/Transaction")
			.WithAutomaticReconnect()
			.Build();

		await con.StartAsync(cancellationToken);

		await con.SendAsync("ReceiveTransaction", notification, cancellationToken);

		await con.DisposeAsync();
	}
}