using Application.Aggregates.Node.Commands;
using FluentResults;
using Network.Services;
using Persistence;
using Persistence.Base;

namespace Application.Aggregates.Node.CommandHandlers;

public class CreateNodeCommandHandler : Base.IRequestHandler<CreateNodeCommand>
{
	public INodeClientService ClientService { get; }
	public ICommandUnitOfWork CommandUnitOfWork { get; }

	public CreateNodeCommandHandler(INodeClientService clientService,ICommandUnitOfWork commandUnitOfWork)
	{
		ClientService = clientService;
		CommandUnitOfWork = commandUnitOfWork;
	}

	public async Task<Result> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
	{
		var NodeAlive = await
			ClientService.TestNodeAlive($"http://{request.Ip}:{request.Port}", cancellationToken);

		if (NodeAlive.IsSuccess)
		{
			var node =
				Domain.Aggregates.Node.Node.Create(request.Name, request.AccountAddress, request.Ip,
				request.Port);
			if (node.IsSuccess)
			{
				var repo
				
			}
		}

		return Result.Ok();

	}
}