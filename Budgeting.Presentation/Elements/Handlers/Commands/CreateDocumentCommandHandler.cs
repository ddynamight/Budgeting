using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Elements;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Commands
{
     public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, CreateDocumentCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public CreateDocumentCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<CreateDocumentCommandResult> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
          {
               var document = _mapper.Map<Document>(request);
               document.Date = DateTime.Now;
               document.AddDomainEvent(new DocumentCreatedEvent(document));
               await _context.Documents.AddAsync(document, cancellationToken);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new DocumentCreatedEvent(document), cancellationToken);

               return _mapper.Map(document, new CreateDocumentCommandResult());
          }
     }
}