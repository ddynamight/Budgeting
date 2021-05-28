using System;

namespace Budgeting.Presentation.Elements.Models.Results
{
     public class UpdateElementCommandResult
     {
          public Guid Id { get; set; }
          public string Title { get; set; }
          public DateTime Date { get; set; }
          public decimal Amount { get; set; }
          public bool IsFixed { get; set; }
          public bool IsApproved { get; set; }
          public Guid BudgetId { get; set; }
     }
}