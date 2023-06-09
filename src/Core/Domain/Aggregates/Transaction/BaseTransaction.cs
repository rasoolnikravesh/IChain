using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;
using FluentResults;
using Utility;

namespace Domain.Aggregates.Transaction;

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

	public static Result<BaseTransaction> Create(string from, string to)
	{
		Result<BaseTransaction> result = new();

		BaseTransaction data = new(from, to);

		result.WithValue(data);

		return result;

	}




	public string From { get; }

	public string To { get; }

	public string Hash => HashUtility.ComputeSha256Hash($"{From}{To}");
}