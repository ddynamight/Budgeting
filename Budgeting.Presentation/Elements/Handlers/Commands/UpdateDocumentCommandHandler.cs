using AutoMapper;
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
     public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, UpdateDocumentCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public UpdateDocumentCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<UpdateDocumentCommandResult> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
          {
               var documentFromDb = await _context.Documents.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               var document = _mapper.Map(request, documentFromDb);
               document.AddDomainEvent(new DocumentUpdatedEvent(document));

               _context.Documents.Attach(document);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new DocumentUpdatedEvent(document), cancellationToken);

               return _mapper.Map(document, new UpdateDocumentCommandResult());
          }
     }
}