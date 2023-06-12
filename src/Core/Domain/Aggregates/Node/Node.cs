using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Transaction;
using Domain.SeedWork;
using FluentResults;

namespace Domain.Aggregates.Node;

public class Node : AggregateRoot
{
	//public 

#pragma warning disable CS8618
	protected Node()
#pragma warning restore CS8618
	{

	}

	protected Node(string name, string accountName, string ip, ushort port, bool self)
	{
		Ip = ip;
		Port = port;
		Name = name;
		Self = self;
		AccountName = accountName;
	}

	public static Result<Node> Create(string name, string accountName, string ip, ushort port)
	{
		Result<Node> result = new();

		Node data = new(name, accountName, ip, port, false);

		result.WithValue(data);

		return result;
	}

	public static Result<Node> CreateSelf(string name, string accountAddress)
	{
		Result<Node> result = new();

		Node data = new(name, accountAddress, "", 0, true);

		result.WithValue(data);

		return result;
	}


	public string Name { get; }

	public string AccountName { get; }

	public string Ip { get; }

	public ushort Port { get; }

	public bool Self { get; }

}