using Application.Aggregates.Node.Commands;
using Application.Aggregates.Node.Queries;
using FluentResults;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Network.Grpc.Services;
using Status = Network.Grpc.Services.Status;

namespace Validator.Services
{
	public class NodeServerService : Node.NodeBase
	{
		public ISender Sender { get; }

		public NodeServerService(ISender sender)
		{
			Sender = sender;
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

		public override async Task<AddNodeResponse> AddNode(AddNodeRequest request, ServerCallContext context)
		{
			Result result =
				await Sender.Send(new CreateNodeCommand(request.Name, request.Url, (ushort)request.Port,
					request.Address));
			if (result.IsSuccess)
				return new AddNodeResponse()
				{
					Status = Status.Success,
				};
			return new AddNodeResponse();
		}
	}
}
