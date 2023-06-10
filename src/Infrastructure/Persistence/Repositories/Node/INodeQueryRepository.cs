using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Base;

namespace Persistence.Repositories.Node
{
	public interface INodeQueryRepository : IQueryRepository<Domain.Aggregates.Node.Node>
	{ 
	}
}
