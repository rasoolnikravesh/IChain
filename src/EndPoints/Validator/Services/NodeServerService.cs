using Application.Aggregates.Node.Queries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Network.Grpc.Services;

namespace Validator.Services
{
	public class NodeServerService : Node.NodeBase
	{
		public ISender Sender { get; }

		public NodeServerService(ISender sender)
		{
			Sender = sender;
		}

		public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			return new HelloReply() { Message = "Sdfsdf" };
		}

		public override async Task<NodeAliveResponse> NodeAlive(Empty request, ServerCallContext context)
		{
			var result = await Sender.Send(request: new GetSelfNodeAliveQuery());
			if (result.IsSuccess)
				return new NodeAliveResponse() { Message = result.Value, Status = true };

			return new NodeAliveResponse()
			{
				Message = "",
				Status = false
			};

		}
	}
}
