using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class CreateDocumentCommand : IRequest<CreateDocumentCommandResult>
     {
          public string Name { get; set; }
          public string Url { get; set; }
          public Guid ElementId { get; set; }
     }
}
