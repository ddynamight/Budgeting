using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class DocumentUpdatedEventHandler : INotificationHandler<DocumentUpdatedEvent>
     {
          private readonly ILogger<DocumentUpdatedEventHandler> _logger;

          public DocumentUpdatedEventHandler(ILogger<DocumentUpdatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(DocumentUpdatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Document.DomainEvents;

               _logger.LogInformation($"Document Updated Event: {domainEvent.GetType().Name} succeeded for Document with Name: {notification.Document.Name} and Id: {notification.Document.Id}");

               return Task.CompletedTask;
          }

     }
}