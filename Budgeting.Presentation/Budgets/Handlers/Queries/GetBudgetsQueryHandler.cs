using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Presentation.Budgets.Models.Results;
using Budgeting.Presentation.Budgets.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Queries
{
     public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, List<GetBudgetQueryResult>>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public GetBudgetsQueryHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<List<GetBudgetQueryResult>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
          {
               var budgets = await _context.Budgets.ToListAsync(cancellationToken);
               return _mapper.Map<List<GetBudgetQueryResult>>(budgets);
          }
     }
}