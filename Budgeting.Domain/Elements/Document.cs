using Budgeting.Domain.Common;
using System;
using System.Collections.Generic;

namespace Budgeting.Domain.Elements
{
     public class Document : Entity, IHasDomainEvent
     {
          public string Name { get; set; }
          public string Url { get; set; }
          public DateTime Date { get; set; }
          public Guid ElementId { get; set; }

          public new List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

          // One to Many Documents Relationship
          public virtual Element Element { get; set; }
     }
}
