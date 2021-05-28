using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class DocumentAccessedEventHandler : INotificationHandler<DocumentAccessedEvent>
     {
          private readonly ILogger<DocumentAccessedEventHandler> _logger;

          public DocumentAccessedEventHandler(ILogger<DocumentAccessedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(DocumentAccessedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Document.DomainEvents;

               _logger.LogInformation($"Document Accessed Event: {domainEvent.GetType().Name} succeeded for Document with Name: {notification.Document.Name} and Id: {notification.Document.Id}");

               return Task.CompletedTask;
          }
     }
}