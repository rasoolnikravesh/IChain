using Application.Aggregates.Node.Commands;
using Application.Aggregates.Node.Queries;
using MediatR;

namespace Application.Services;

public class StartService : IStartService
{
	public IMediator Mediator { get; }

	public StartService(IMediator mediator)
	{
		Mediator = mediator;
	}

	public async Task StartAsync()
	{
		//var nodes = await Mediator.Send(new GetNodesFromSettingQuery());
		//if (nodes.IsSuccess)
		//{
		//	Console.WriteLine("Started Communication with Nodes");
		//	await Mediator.Send(new StartCommunicationCommand(nodes.Value));
		//}
		//else
		//{

		//	Console.WriteLine("Started Without Any Nodes");
		//}

	}
}