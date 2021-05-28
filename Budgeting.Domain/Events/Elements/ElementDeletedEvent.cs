using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class ElementDeletedEvent : INotification
     {
          public ElementDeletedEvent(Element element)
          {
               Element = element;
          }

          public Element Element { get; }
     }
}