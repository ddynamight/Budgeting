using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System.Collections.Generic;

namespace Budgeting.Presentation.Elements.Queries
{
     public class GetElementsQuery : IRequest<List<GetElementQueryResult>>
     {
     }
}
