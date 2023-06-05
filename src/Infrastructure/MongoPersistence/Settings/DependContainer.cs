using Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDBPersistence.Base;
using MongoDBPersistence.Repositories.Transaction;
using Persistence;
using Persistence.Repositories.Transaction;
using Persistence.RepositoryCollection;

namespace MongoDBPersistence.Settings;

public static class DependContainer
{

	private static readonly RepositoryCollection queryCollection;
	private static readonly RepositoryCollection commandCollection;
	static DependContainer()
	{
		queryCollection = new RepositoryCollection();
		commandCollection = new RepositoryCollection();

		queryCollection.AddFromAssembly(typeof(ITransactionQueryRepository), typeof(TransactionQueryRepository));
		commandCollection.AddFromAssembly(typeof(ITransactionCommandRepository), typeof(TransactionCommandRepository));
	}


	public static IServiceCollection AddUnitOfWork(
		this IServiceCollection services,
		InitialSetting setting)
	{

		services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>(_ =>
			new CommandUnitOfWork(
				new MongoContext(setting),
				commandCollection.DeepCopy()));

		services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>(_ =>
			new QueryUnitOfWork(
				new MongoContext(setting),
				queryCollection.DeepCopy()));



		BsonClassMap.RegisterClassMap<Entity>(x =>
		{
			x.MapIdMember(x => x.Id).SetOrder(1);
			x.AutoMap();
		});

		return services;
	}
}