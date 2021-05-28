using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Budgets;
using Budgeting.Presentation.Budgets.Commands;
using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Commands
{
     public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, UpdateBudgetCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public UpdateBudgetCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<UpdateBudgetCommandResult> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
          {
               var budgetFromDb = await _context.Budgets.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               var budget = _mapper.Map(request, budgetFromDb);
               budget.AddDomainEvent(new BudgetUpdatedEvent(budget));

               _context.Budgets.Attach(budget);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new BudgetUpdatedEvent(budget), cancellationToken);

               return _mapper.Map(budget, new UpdateBudgetCommandResult());
          }
     }
}