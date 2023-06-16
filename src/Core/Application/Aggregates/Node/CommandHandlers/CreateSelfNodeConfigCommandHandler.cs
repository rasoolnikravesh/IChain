using Application.Aggregates.Node.Commands;
using Application.Aggregates.Node.Models;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using Network.Services;
using Persistence;
using Persistence.Repositories.Node;

namespace Application.Aggregates.Node.CommandHandlers;

public class CreateSelfNodeConfigCommandHandler : Base.IRequestHandler<CreateSelfNodeConfigCommand, string>
{
	public CreateSelfNodeConfigCommandHandler(INodeClientService clientService, ICommandUnitOfWork commandUnitOfWork)
	{
		ClientService = clientService;
		CommandUnitOfWork = commandUnitOfWork;
	}

	public INodeClientService ClientService { get; }
	public ICommandUnitOfWork CommandUnitOfWork { get; }

	public async Task<Result<string>> Handle(CreateSelfNodeConfigCommand request, CancellationToken cancellationToken)
	{
		var result = new Result<string>();
		
		var node = Domain.Aggregates.Node.Node.CreateSelf(request.Name, request.AccountAddress);
		if (node.IsFailed)
			return result.WithErrors(node.Errors);

		INodeCommandRepository repo = (INodeCommandRepository)CommandUnitOfWork.GetCommandRepository<Domain.Aggregates.Node.Node>();
		Result addResult = await repo.AddAsync(node.Value, cancellationToken);

		return addResult.IsSuccess ? result.WithSuccess(node.Value.Id.ToString()) : result.WithErrors(addResult.Errors);
	}
}