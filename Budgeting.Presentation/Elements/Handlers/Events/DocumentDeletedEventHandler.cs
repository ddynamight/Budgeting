using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class DocumentDeletedEventHandler : INotificationHandler<DocumentDeletedEvent>
     {
          private readonly ILogger<DocumentDeletedEventHandler> _logger;

          public DocumentDeletedEventHandler(ILogger<DocumentDeletedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(DocumentDeletedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Document.DomainEvents;

               _logger.LogInformation($"Document Deleted Event: {domainEvent.GetType().Name} succeeded for Document with Name: {notification.Document.Name} and Id: {notification.Document.Id}");

               return Task.CompletedTask;
          }

     }
}