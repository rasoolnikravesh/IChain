using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aggregates.Node.Commands;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class NodeController : ApiControllerBase
	{
		public NodeController(ISender sender, IPublisher publisher) : base(sender, publisher)
		{
		}

		[HttpPost]
		public async Task<IActionResult> CreateNode(CreateNodeCommand command)
		{
			Result result = await Sender.Send(command);

			if (result.IsSuccess)
				return BadRequest(result);
			return Ok(result);
		}
	}
}
