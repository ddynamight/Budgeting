using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class ElementAccessedEvent : INotification
     {
          public ElementAccessedEvent(Element element)
          {
               Element = element;
          }

          public Element Element { get; }
     }
}