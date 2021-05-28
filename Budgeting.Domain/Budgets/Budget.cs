using Budgeting.Domain.Common;
using Budgeting.Domain.Elements;
using System;
using System.Collections.Generic;

namespace Budgeting.Domain.Budgets
{
     public class Budget : Entity, IHasDomainEvent
     {
          public string Year { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One Budget to Many Relationship
          public virtual ICollection<Element> Elements { get; set; } = new HashSet<Element>();
     }
}
