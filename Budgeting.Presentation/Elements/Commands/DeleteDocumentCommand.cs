using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class DeleteDocumentCommand : IRequest<DeleteDocumentCommandResult>
     {
          public Guid Id { get; set; }
     }
}