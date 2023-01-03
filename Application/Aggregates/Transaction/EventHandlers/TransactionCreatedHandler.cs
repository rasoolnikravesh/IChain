using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aggregates.Transaction.Events;

namespace Application.Aggregates.Transaction.EventHandlers
{
	public class TransactionCreatedHandler:MediatR.INotificationHandler<TransactionCreated>
	{
		public async Task Handle(TransactionCreated notification, CancellationToken cancellationToken)
		{
			//throw new NotImplementedException();
		}
	}
}
