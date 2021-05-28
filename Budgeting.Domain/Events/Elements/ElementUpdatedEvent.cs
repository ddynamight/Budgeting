using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class ElementUpdatedEvent : INotification
     {
          public ElementUpdatedEvent(Element element)
          {
               Element = element;
          }

          public Element Element { get; }
     }
}