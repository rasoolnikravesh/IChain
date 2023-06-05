using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace NetworkBase;

public class ClientService : IClientService
{
	private static readonly ConcurrentDictionary<string, HubConnection> _connections;



	static ClientService()
	{
		_connections = new ConcurrentDictionary<string, HubConnection>();
	}

	public bool Add(string Name, HubConnection connection)
	{
		return _connections.TryAdd(Name, connection);
	}


	public bool Remove(string name)
	{
		return _connections.TryRemove(name, out var _);
	}

	//public void AddOrUpdate(string name, HubConnection hub)
	//{
	//	_connections.AddOrUpdate(name, hub)
	//}

	public bool Get(string Name, out HubConnection? hub)
	{
		return _connections.TryGetValue(Name, out hub);
	}


}