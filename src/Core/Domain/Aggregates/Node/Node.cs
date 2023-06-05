using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.Node;

public class Node : AggregateRoot
{
	public string Name { get; set; }

	public string AccountName { get; set; }
}