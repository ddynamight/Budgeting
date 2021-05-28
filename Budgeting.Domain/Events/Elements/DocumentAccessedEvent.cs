using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class DocumentAccessedEvent : INotification
     {
          public DocumentAccessedEvent(Document document)
          {
               Document = document;
          }

          public Document Document { get; }
     }
}