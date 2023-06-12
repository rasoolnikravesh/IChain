using Application.Aggregates.Transaction.Commands;
using Application.Aggregates.Transaction.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Base;
using Application.Services;
using MediatR;

namespace Application.Settings;

public static class DependecyContainer
{
	public static IServiceCollection AddServices(this IServiceCollection collection)
	{
		collection.AddValidatorsFromAssembly(typeof(CreateTransactionValidation).Assembly);

		collection.AddMediatR(Assembly.GetAssembly(typeof(CreateTransactionCommand))!);



		collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		//collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(EventBehavior<,>));

		collection.AddSingleton<IBlockChain, BlockChain>();

		return collection;
	}
}