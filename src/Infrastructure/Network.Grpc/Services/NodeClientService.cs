using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

namespace Network.Grpc.Services
{
	public class NodeClientService : Network.Services.INodeClientService
	{

		public NodeClientService()
		{
		}

		

		public async Task<Result<string>> TestNodeAlive(string address, CancellationToken cancellationToken)
		{
			GrpcChannel channel = GrpcChannel.ForAddress(address);
			Node.NodeClient client = new(channel);

			NodeAliveResponse? result = await client.NodeAliveAsync(new Empty(), null, null, cancellationToken);
			return result.Status ? Result.Ok(result.Message) : Result.Fail("");
		}
	}
}
