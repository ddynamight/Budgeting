using Budgeting.Domain.Elements;
using MediatR;

namespace Budgeting.Domain.Events.Elements
{
     public class DocumentDeletedEvent : INotification
     {
          public DocumentDeletedEvent(Document document)
          {
               Document = document;
          }

          public Document Document { get; }
     }
}