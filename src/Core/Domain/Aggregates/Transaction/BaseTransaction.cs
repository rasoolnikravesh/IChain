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

public abstract class BaseTransaction : AggregateRoot
{
#pragma warning disable CS8618
	protected BaseTransaction()
#pragma warning restore CS8618
	{

	}

	protected BaseTransaction(string from, string to, string signature, string publicKey)
	{
		From = from;
		To = to;
		Signature = signature;
		PublicKey = publicKey;
	}



	public abstract string GetHashData();

	public string From { get; }

	public string To { get; }

	public string Hash => HashUtility.ComputeSha256Hash(GetHashData());

	public string Signature { get; }

	public string PublicKey { get; }
}