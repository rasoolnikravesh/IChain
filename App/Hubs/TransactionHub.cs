using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.SignalR;

namespace App.Hubs
{
	public class TransactionHub : Hub
	{
		public TransactionHub()
		{

		}

		//public async Task BroadCast(string message, CancellationToken cancellationToken)
		//{
		//	await Clients.All.SendAsync("ReceiveTransaction", message, cancellationToken: cancellationToken);

		//}

	}
}
