using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Budgets;
using Budgeting.Presentation.Budgets.Models.Results;
using Budgeting.Presentation.Budgets.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Queries
{
     public class GetBudgetQueryHandler : IRequestHandler<GetBudgetQuery, GetBudgetQueryResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public GetBudgetQueryHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<GetBudgetQueryResult> Handle(GetBudgetQuery request, CancellationToken cancellationToken)
          {
               var budget = await _context.Budgets.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               await _mediator.Publish(new BudgetAccessedEvent(budget), cancellationToken);
               return _mapper.Map<GetBudgetQueryResult>(budget);
          }
     }
}
