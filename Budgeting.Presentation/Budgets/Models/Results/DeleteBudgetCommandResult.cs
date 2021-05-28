using System;

namespace Budgeting.Presentation.Budgets.Models.Results
{
     public class DeleteBudgetCommandResult
     {
          public Guid Id { get; set; }
          public bool IsDeleted { get; set; }
          public string Message { get; set; }
     }
}