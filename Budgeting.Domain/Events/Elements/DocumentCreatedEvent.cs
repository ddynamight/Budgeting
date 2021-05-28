using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class DocumentCreatedEvent : INotification
     {
          public DocumentCreatedEvent(Document document)
          {
               Document = document;
          }

          public Document Document { get; }
     }
}