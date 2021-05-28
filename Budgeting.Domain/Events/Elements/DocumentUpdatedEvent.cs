using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class DocumentUpdatedEvent : INotification
     {
          public DocumentUpdatedEvent(Document document)
          {
               Document = document;
          }

          public Document Document { get; }
     }
}