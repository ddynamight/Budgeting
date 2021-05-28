using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Budgets.Commands
{
     public class UpdateBudgetCommand : IRequest<UpdateBudgetCommandResult>
     {
          public Guid Id { get; set; }
          public string Year { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
     }
}