using Application.Aggregates.Node.Commands;
using Application.Aggregates.Node.Models;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Application.Aggregates.Node.CommandHandlers;

//public class StartCommunicationCommandHandler : Base.IRequestHandler<StartCommunicationCommand>
//{
//	public IClientService ClientService { get; }
//	public IMediator Mediator { get; }

//	public StartCommunicationCommandHandler(IClientService clientService, IMediator mediator)
//	{
//		ClientService = clientService;
//		Mediator = mediator;
//	}

//	public Task<Result> Handle(StartCommunicationCommand request, CancellationToken cancellationToken)
//	{

//		//await Mediator.Publish(new TransactionCreated(), cancellationToken);
//		foreach (NodeInformation node in request.Nodes)
//		{
//			if (ClientService.Get(node.Name, out HubConnection? _))
//			{

//			}
//		}

//		return Task.FromResult(Result.Ok());
//	}
//}