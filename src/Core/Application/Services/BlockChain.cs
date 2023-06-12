using Application.Aggregates.Node.Commands;
using Domain.Aggregates.Node;
using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories.Node;

namespace Application.Services;

internal class BlockChain : IBlockChain
{
	static BlockChain()
	{
		Console.WriteLine("Validation started");

	}

	public ISender Sender { get; }
	public ICommandUnitOfWork CommandUnitOfWork { get; }
	public IQueryUnitOfWork QueryUnitOfWork { get; }

	public BlockChain(IServiceProvider provider)
	{
		using AsyncServiceScope scope = provider.CreateAsyncScope();

		Sender = scope.ServiceProvider.GetRequiredService<ISender>();
		CommandUnitOfWork = scope.ServiceProvider.GetRequiredService<ICommandUnitOfWork>();
		QueryUnitOfWork = scope.ServiceProvider.GetRequiredService<IQueryUnitOfWork>();

		Start().Wait();
	}

	public void Test()
	{

	}

	private async Task Start()
	{
		INodeQueryRepository nodeRepo = (INodeQueryRepository)QueryUnitOfWork.GetQueryRepository<Node>();
		if (!await nodeRepo.SelfNodeConfiged())
			await Sender.Send(new CreateSelfNodeConfigCommand("Rasool", "Asdk234xvsa52kfgi2"));

		var res = await nodeRepo.GetSomeAsync(x => x.Self);

		Node me = res.First();




	}
}