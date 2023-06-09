using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiControllerBase : ControllerBase
	{
		public ISender Sender { get; }
		public IPublisher Publisher { get; }

		public ApiControllerBase(ISender sender, IPublisher publisher)
		{
			Sender = sender;
			Publisher = publisher;
		}
	}
}
