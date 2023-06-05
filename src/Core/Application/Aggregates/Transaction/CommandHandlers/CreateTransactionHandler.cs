using System.Diagnostics;
using Application.Aggregates.Transaction.Commands;
using Application.Aggregates.Transaction.Events;
using Application.Base;
using FluentResults;
using Persistence;
using Persistence.Repositories.Transaction;

namespace Application.Aggregates.Transaction.CommandHandlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransaction, Domain.Aggregates.Transaction.StringTransaction>
{
	public ICommandUnitOfWork UnitOfWork { get; }

	public ITransactionCommandRepository Repository { get; }

	public CreateTransactionHandler(ICommandUnitOfWork unitOfWork)
	{
		UnitOfWork = unitOfWork;
		var watch = Stopwatch.StartNew();
		Repository = (ITransactionCommandRepository)UnitOfWork.GetCommandRepository<Domain.Aggregates.Transaction.StringTransaction>();
		watch.Stop();
		Console.WriteLine($"Repository Geted in {watch.ElapsedMilliseconds}");


	}

	public async Task<Result<Domain.Aggregates.Transaction.StringTransaction>> Handle(CreateTransaction request, CancellationToken cancellationToken)
	{

		var transaction = Domain.Aggregates.Transaction.StringTransaction.Create(request.From, request.To, request.Data);

		Result addResult = await Repository.AddAsync(transaction.Value, cancellationToken);

		transaction.Value.RaiseDomainEvent(new TransactionCreated()
		{
			Created = transaction.Value.RegisterDate,
			Data = transaction.Value.Data,
			From = transaction.Value.From,
			To = transaction.Value.To,
			Id = transaction.Value.Id,
		});

		return addResult.IsSuccess ? Result.Ok(transaction.Value) : addResult;
	}
}