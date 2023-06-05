using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aggregates.Node.Models;
using Application.Base;
using MediatR;

namespace Application.Aggregates.Node.Queries;

public class GetNodesFromSettingQuery : IQuery<List<NodeInformation>>
{

}