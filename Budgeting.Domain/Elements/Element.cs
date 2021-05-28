using Budgeting.Domain.Common;
using System;
using System.Collections.Generic;
using Budgeting.Domain.Budgets;

namespace Budgeting.Domain.Elements
{
     public class Element : Entity, IHasDomainEvent
     {
          public string Title { get; set; }
          public DateTime Date { get; set; }
          public decimal Amount { get; set; }
          public bool IsFixed { get; set; }
          public bool IsApproved { get; set; }
          public Guid BudgetId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Elements Relationship
          public virtual Budget Budget { get; set; }

          // One Element to Many Relationship
          public virtual ICollection<Document> Documents { get; set; } = new HashSet<Document>();
     }
}