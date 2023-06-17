using Application.Aggregates.Transaction.Commands;
using Application.Aggregates.Transaction.Events;
using Domain.Aggregates.Transaction;
using FluentResults;
using MediatR;
using Persistence;
using Persistence.Repositories.Transaction;

namespace Application.Aggregates.Transaction.CommandHandlers;

public class CreateTransactionHandler : Base.IRequestHandler<CreateTransactionCommand, MoneyTransaction>
{
	public ICommandUnitOfWork UnitOfWork { get; }
	public IPublisher Publisher { get; }

	public ITransactionCommandRepository Repository { get; }

	public CreateTransactionHandler(ICommandUnitOfWork unitOfWork, IPublisher publisher)
	{
		UnitOfWork = unitOfWork;
		Publisher = publisher;
		Repository = (ITransactionCommandRepository)UnitOfWork.GetCommandRepository<BaseTransaction>();

	}

	public async Task<Result<MoneyTransaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
	{

		var transaction =
			MoneyTransaction.Create(request.From, request.To, request.Amount, request.Fee, request.Signature, request.PublicKey);

		if (transaction.IsFailed)
			return transaction;
		MoneyTransaction? trx = transaction.Value;
		Result addResult = await Repository.AddAsync(trx, cancellationToken);
		if (addResult.IsSuccess)
			transaction.Value.RaiseDomainEvent(new MoneyTransactionCreated()
			{
				To = trx.To,
				Id = trx.Id,
				Fee = trx.Fee,
				From = trx.From,
				Amount = trx.Amount,
				PublicKey = trx.PublicKey,
				Signature = trx.Signature,
				Created = trx.RegisterDate,
			});
		await Publisher.Publish(transaction.Value.DomainEvents.FirstOrDefault()!,cancellationToken);

		transaction.Value.ClearDomainEvents();

		return addResult.IsSuccess ? Result.Ok(trx) : addResult;
	}
}