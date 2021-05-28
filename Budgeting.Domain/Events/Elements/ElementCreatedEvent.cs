using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class ElementCreatedEvent : INotification
     {
          public ElementCreatedEvent(Element element)
          {
               Element = element;
          }

          public Element Element { get; }
     }
}
