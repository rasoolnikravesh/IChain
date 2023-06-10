using Application.Aggregates.Node.Commands;
using FluentResults;
using Network.Services;
using Persistence;

namespace Application.Aggregates.Node.CommandHandlers;

public class CreateNodeCommandHandler : Base.IRequestHandler<CreateNodeCommand>
{
	public INodeClientService ClientService { get; }
	public ICommandUnitOfWork CommandUnitOfWork { get; }

	public CreateNodeCommandHandler(INodeClientService clientService, ICommandUnitOfWork commandUnitOfWork)
	{
		ClientService = clientService;
		CommandUnitOfWork = commandUnitOfWork;
	}

	public async Task<Result> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
	{
		var nodeAlive = await
			ClientService.TestNodeAlive($"http://{request.Ip}:{request.Port}", cancellationToken);

		if (nodeAlive.IsFailed) return Result.Ok();
		var node =
			Domain.Aggregates.Node.Node.Create(request.Name, request.AccountAddress, request.Ip,
				request.Port);

		if (node.IsFailed) return Result.Ok();

		var repo = CommandUnitOfWork.GetCommandRepository<Domain.Aggregates.Node.Node>();

		Result result = await repo.AddAsync(node.Value, cancellationToken);

		return result;

	}
}