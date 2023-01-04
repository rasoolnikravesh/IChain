using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace NetworkBase
{
	public class ClientService : IClientService
	{
		private readonly IDictionary<string, HubConnection> _connections;

		public ClientService(IDictionary<string, HubConnection>? connections = default)
		{
			_connections = connections ?? new Dictionary<string, HubConnection>();
		}

		public void Add(string Name, HubConnection connection)
		{
			_connections.Add(Name,connection);
		}




	}
}
