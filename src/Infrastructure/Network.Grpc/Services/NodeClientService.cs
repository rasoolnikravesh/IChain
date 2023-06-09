using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Network.Grpc.Services
{
	public class NodeClientService : Network.Services.INodeClientService
	{
		public Node.NodeClient Client { get; }

		public NodeClientService()
		{
			GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5136");
			Client ??= new Node.NodeClient(channel);
		}

		public async Task Test()
		{
			var s = await Client.SayHelloAsync(new HelloRequest() { Name = "sdsds" });
		}
	}
}
