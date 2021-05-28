using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class DocumentCreatedEventHandler : INotificationHandler<DocumentCreatedEvent>
     {
          private readonly ILogger<DocumentCreatedEventHandler> _logger;

          public DocumentCreatedEventHandler(ILogger<DocumentCreatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(DocumentCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Document.DomainEvents;

               _logger.LogInformation($"Document Created Event: {domainEvent.GetType().Name} succeeded for Document with Name: {notification.Document.Name} and Id: {notification.Document.Id}");

               return Task.CompletedTask;
          }
     }
}
