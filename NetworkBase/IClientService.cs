using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace NetworkBase
{
	public interface IClientService
	{
		void Add(string Name, HubConnection connection);
	}
}
