using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class CreateElementCommand : IRequest<CreateElementCommandResult>
     {
          public string Title { get; set; }
          public decimal Amount { get; set; }
          public bool IsFixed { get; set; }
          public bool IsApproved { get; set; }
          public Guid BudgetId { get; set; }
     }
}