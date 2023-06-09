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

	protected Node(string name, string accountName, string ip, ushort port)
	{
		Ip = ip;
		Port = port;
		Name = name;
		AccountName = accountName;
	}

	public static Result<Node> Create(string name, string accountName, string ip, ushort port)
	{
		Result<Node> result = new();

		Node data = new(name, accountName, ip, port);

		result.WithValue(data);

		return result;
	}


	public string Name { get; }

	public string AccountName { get; }

	public string Ip { get; }

	public ushort Port { get; }

}