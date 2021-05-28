using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Elements.Commands
{
     public class UpdateElementCommand : IRequest<UpdateElementCommandResult>
     {
          public Guid Id { get; set; }
          public string Title { get; set; }
          public decimal Amount { get; set; }
          public bool IsFixed { get; set; }
          public bool IsApproved { get; set; }
          public Guid BudgetId { get; set; }
     }
}