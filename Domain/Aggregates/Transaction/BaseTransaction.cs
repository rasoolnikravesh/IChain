using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;
using FluentResults;

namespace Domain.Aggregates.Transaction
{
	public class BaseTransaction : AggregateRoot
	{
#pragma warning disable CS8618
		protected BaseTransaction()
#pragma warning restore CS8618
		{

		}

		protected BaseTransaction(string from, string to)
		{
			From = from;
			To = to;
		}

		public static Result<BaseTransaction> Create(string From, string To)
		{
			Result<BaseTransaction> result = new();

			BaseTransaction data = new(From, To);

			result.WithValue(data);

			return result;

		}




		public string From { get; private set; }

		public string To { get; private set; }
	}
}
