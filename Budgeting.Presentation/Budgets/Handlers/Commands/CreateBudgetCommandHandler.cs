using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Budgets;
using Budgeting.Domain.Events.Budgets;
using Budgeting.Presentation.Budgets.Commands;
using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Commands
{
     public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, CreateBudgetCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public CreateBudgetCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<CreateBudgetCommandResult> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
          {
               var budget = _mapper.Map<Budget>(request);
               budget.Date = DateTime.Now;
               budget.AddDomainEvent(new BudgetCreatedEvent(budget));
               await _context.Budgets.AddAsync(budget, cancellationToken);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new BudgetCreatedEvent(budget), cancellationToken);

               return _mapper.Map(budget, new CreateBudgetCommandResult());
          }
     }
}