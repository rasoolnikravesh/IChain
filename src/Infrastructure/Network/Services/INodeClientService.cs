using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;

namespace Network.Services
{
	public interface INodeClientService
	{
		Task Test();

		Task<Result<string>> TestNodeAlive(string address, CancellationToken cancellationToken);
	}
}
