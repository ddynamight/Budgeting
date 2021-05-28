using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Queries
{
     public class GetElementQuery : IRequest<GetElementQueryResult>
     {
          public Guid Id { get; set; }
     }
}