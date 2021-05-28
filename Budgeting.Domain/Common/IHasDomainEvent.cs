using System.Collections.Generic;

namespace Budgeting.Domain.Common
{
     public interface IHasDomainEvent
     {
          public List<DomainEvent> DomainEvents { get; set; }
     }
}