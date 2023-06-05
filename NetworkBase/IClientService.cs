using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace NetworkBase;

public interface IClientService
{
	bool Add(string Name, HubConnection connection);
	bool Remove(string name);
	bool Get(string Name, out HubConnection? hub);
}