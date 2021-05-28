using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class UpdateDocumentCommand : IRequest<UpdateDocumentCommandResult>
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public string Url { get; set; }
          public Guid ElementId { get; set; }
     }
}