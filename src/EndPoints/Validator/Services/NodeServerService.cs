using Grpc.Core;
using Network.Grpc.Services;
using Network.Services;

namespace Validator.Services
{
	public class NodeServerService : Node.NodeBase
	{
		public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			return new HelloReply() { Message = "Sdfsdf" };
		}
	}
}
