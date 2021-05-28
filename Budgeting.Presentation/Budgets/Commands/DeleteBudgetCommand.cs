using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Budgets.Commands
{
     public class DeleteBudgetCommand : IRequest<DeleteBudgetCommandResult>
     {
          public Guid Id { get; set; }
     }
}