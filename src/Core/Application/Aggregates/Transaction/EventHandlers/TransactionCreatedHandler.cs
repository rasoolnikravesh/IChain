//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Application.Aggregates.Transaction.Events;
//using Microsoft.AspNetCore.SignalR.Client;
//using NetworkBase;

//namespace Application.Aggregates.Transaction.EventHandlers;

//public class TransactionCreatedHandler : MediatR.INotificationHandler<TransactionCreated<double>>
//{
//	public IClientService Service { get; }

//	private readonly HubConnection con;

//	public TransactionCreatedHandler(IClientService service)
//	{
//		Service = service;

//	}

//	public Task Handle(TransactionCreated<double> notification, CancellationToken cancellationToken)
//	{

//		//if (con.State == HubConnectionState.Disconnected)
//		//{
//		//	await con.StartAsync(cancellationToken);
//		//}

//		//con.Closed += Con_Closed;

//		//con.On("Test", (string s) =>
//		//{
//		//	Console.WriteLine(s);
//		//});

//		//await con.StartAsync(cancellationToken).WaitAsync(cancellationToken);

//		//await con.SendAsync("ReceiveTransaction", notification, cancellationToken);
//		throw new NotImplementedException();
//	}
//}