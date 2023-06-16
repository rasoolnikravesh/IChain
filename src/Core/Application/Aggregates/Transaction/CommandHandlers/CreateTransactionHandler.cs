using Application.Aggregates.Transaction.Commands;
using Application.Aggregates.Transaction.Events;
using Application.Base;
using Domain.Aggregates.Transaction;
using FluentResults;
using Persistence;
using Persistence.Repositories.Transaction;

namespace Application.Aggregates.Transaction.CommandHandlers;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Domain.Aggregates.Transaction.MoneyTransaction>
{
	public ICommandUnitOfWork UnitOfWork { get; }

	public ITransactionCommandRepository Repository { get; }

	public CreateTransactionHandler(ICommandUnitOfWork unitOfWork)
	{
		UnitOfWork = unitOfWork;
		Repository = (ITransactionCommandRepository)UnitOfWork.GetCommandRepository<BaseTransaction>();

	}

	public async Task<Result<MoneyTransaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
	{

		var transaction =
			MoneyTransaction.Create(request.From, request.To, request.Amount, request.Fee,"","");

		if (transaction.IsFailed)
			return transaction;
		MoneyTransaction? trx = transaction.Value;
		Result addResult = await Repository.AddAsync(trx, cancellationToken);
		if (addResult.IsSuccess)
			transaction.Value.RaiseDomainEvent(new TransactionCreated<double>()
			{
				Created = trx.RegisterDate,
				Data = trx.Amount,
				From = trx.From,
				Fee = trx.Fee,
				To = trx.To,
				Id = trx.Id,
			});

		return addResult.IsSuccess ? Result.Ok(trx) : addResult;
	}
}