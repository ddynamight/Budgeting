using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Documents.Handlers.Commands
{
     public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, DeleteDocumentCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMediator _mediator;

          public DeleteDocumentCommandHandler(IAppDbContext _context, IMediator _mediator)
          {
               this._context = _context;
               this._mediator = _mediator;
          }

          public async Task<DeleteDocumentCommandResult> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
          {
               var document = await _context.Documents.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               document.AddDomainEvent(new DocumentDeletedEvent(document));
               _context.Documents.Remove(document);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new DocumentDeletedEvent(document), cancellationToken);

               return new DeleteDocumentCommandResult
               {
                    Id = request.Id,
                    IsDeleted = true,
                    Message = $"Document with Id {request} is deleted successfully"
               };
          }
     }
}
