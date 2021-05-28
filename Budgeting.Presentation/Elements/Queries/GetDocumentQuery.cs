using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Queries
{
     public class GetDocumentQuery : IRequest<GetDocumentQueryResult>
     {
          public Guid Id { get; set; }
     }
}
