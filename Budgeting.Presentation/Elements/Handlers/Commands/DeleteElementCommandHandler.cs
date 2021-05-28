using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Commands
{
     public class DeleteElementCommandHandler : IRequestHandler<DeleteElementCommand, DeleteElementCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMediator _mediator;

          public DeleteElementCommandHandler(IAppDbContext _context, IMediator _mediator)
          {
               this._context = _context;
               this._mediator = _mediator;
          }

          public async Task<DeleteElementCommandResult> Handle(DeleteElementCommand request, CancellationToken cancellationToken)
          {
               var element = await _context.Elements.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               element.AddDomainEvent(new ElementDeletedEvent(element));
               _context.Elements.Remove(element);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new ElementDeletedEvent(element), cancellationToken);

               return new DeleteElementCommandResult
               {
                    Id = request.Id,
                    IsDeleted = true,
                    Message = $"Element with Id {request} is deleted successfully"
               };
          }
     }
}