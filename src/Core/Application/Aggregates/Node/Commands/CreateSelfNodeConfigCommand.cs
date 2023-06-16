using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Base;

namespace Application.Aggregates.Node.Commands
{
	public class CreateSelfNodeConfigCommand : ICommand<string>
	{
		public CreateSelfNodeConfigCommand(string name, string accountAddress)
		{
			Name = name;
			AccountAddress = accountAddress;
		}

		public string Name { get; init; }
		public string AccountAddress { get; init; }

	}
}
