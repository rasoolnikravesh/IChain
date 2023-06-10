using Domain.Aggregates.Node;
using Domain.Aggregates.Transaction;
using Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using Persistence.Mongo.Base;
using Persistence.Mongo.Repositories.Transaction;
using Persistence.Repositories.Transaction;
using Persistence.RepositoryCollection;

namespace Persistence.Mongo.Settings;

public static class DependContainer
{

	private static readonly RepositoryCollection.RepositoryCollection QueryCollection;
	private static readonly RepositoryCollection.RepositoryCollection CommandCollection;
	static DependContainer()
	{
		QueryCollection = new RepositoryCollection.RepositoryCollection();
		CommandCollection = new RepositoryCollection.RepositoryCollection();

		QueryCollection.AddFromAssembly(typeof(ITransactionQueryRepository), typeof(TransactionQueryRepository));
		CommandCollection.AddFromAssembly(typeof(ITransactionCommandRepository), typeof(TransactionCommandRepository));
	}


	public static IServiceCollection AddUnitOfWork(
		this IServiceCollection services,
		InitialSetting setting)
	{

		services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>(_ =>
			new CommandUnitOfWork(
				new MongoContext(setting),
				CommandCollection.DeepCopy()));

		services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>(_ =>
			new QueryUnitOfWork(
				new MongoContext(setting),
				QueryCollection.DeepCopy()));





		return services;
	}
}