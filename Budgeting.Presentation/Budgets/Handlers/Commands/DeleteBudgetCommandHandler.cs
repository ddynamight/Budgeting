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
     public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, DeleteBudgetCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMediator _mediator;

          public DeleteBudgetCommandHandler(IAppDbContext _context, IMediator _mediator)
          {
               this._context = _context;
               this._mediator = _mediator;
          }

          public async Task<DeleteBudgetCommandResult> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
          {
               var budget = await _context.Budgets.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               budget.AddDomainEvent(new BudgetDeletedEvent(budget));
               _context.Budgets.Remove(budget);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new BudgetDeletedEvent(budget), cancellationToken);

               return new DeleteBudgetCommandResult
               {
                    Id = request.Id,
                    IsDeleted = true,
                    Message = $"Budget with Id {request} is deleted successfully"
               };
          }
     }
}