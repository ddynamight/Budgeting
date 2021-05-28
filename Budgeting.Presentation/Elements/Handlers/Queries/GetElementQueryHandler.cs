using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Models.Results;
using Budgeting.Presentation.Elements.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Queries
{
     public class GetElementQueryHandler : IRequestHandler<GetElementQuery, GetElementQueryResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetElementQueryHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<GetElementQueryResult> Handle(GetElementQuery request, CancellationToken cancellationToken)
          {
               var element = await _context.Elements.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               await _mediator.Publish(new ElementAccessedEvent(element), cancellationToken);
               return _mapper.Map<GetElementQueryResult>(element);
          }
     }
}