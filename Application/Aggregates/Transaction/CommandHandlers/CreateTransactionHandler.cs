using Application.Aggregates.Transaction.Commands;
using Application.Aggregates.Transaction.Events;
using Application.Base;
using FluentResults;
using Persistence;
using Persistence.Repositories.Transaction;

namespace Application.Aggregates.Transaction.CommandHandlers
{
	public class CreateTransactionHandler : ICommandHandler<CreateTransaction, Domain.Aggregates.Transaction.Transaction>
	{
		public ICommandUnitOfWork UnitOfWork { get; }

		public ITransactionCommandRepository Repository { get; }

		public CreateTransactionHandler(ICommandUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
			Repository = (ITransactionCommandRepository)UnitOfWork.GetCommandRepository<Domain.Aggregates.Transaction.Transaction>();

		}

		public async Task<Result<Domain.Aggregates.Transaction.Transaction>> Handle(CreateTransaction request, CancellationToken cancellationToken)
		{

			Domain.Aggregates.Transaction.Transaction transaction = new Domain.Aggregates.Transaction.Transaction(request.From, request.To, request.Data);

			Result addResult = await Repository.AddAsync(transaction, cancellationToken);

			transaction.RaiseDomainEvent(new TransactionCreated()
			{
				Created = transaction.RegisterDate,
				Data = transaction.Data,
				From = transaction.From,
				To = transaction.To,
				Id = transaction.Id,
			});

			return addResult.IsSuccess ? Result.Ok(transaction) : addResult;
		}
	}
}
