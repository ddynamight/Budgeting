using System;

namespace Budgeting.Presentation.Budgets.Models.Results
{
     public class UpdateBudgetCommandResult
     {
          public Guid Id { get; set; }
          public string Year { get; set; }
          public DateTime Date { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
     }
}