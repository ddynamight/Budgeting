using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Models.Results;
using Budgeting.Presentation.Elements.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Documents.Handlers.Queries
{
     public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, GetDocumentQueryResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetDocumentQueryHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<GetDocumentQueryResult> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
          {
               var document = await _context.Documents.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               await _mediator.Publish(new DocumentAccessedEvent(document), cancellationToken);
               return _mapper.Map<GetDocumentQueryResult>(document);
          }
     }
}