using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class DeleteElementCommand : IRequest<DeleteElementCommandResult>
     {
          public Guid Id { get; set; }
     }
}
