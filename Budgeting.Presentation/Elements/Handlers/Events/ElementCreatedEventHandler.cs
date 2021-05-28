using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class ElementCreatedEventHandler : INotificationHandler<ElementCreatedEvent>
     {
          private readonly ILogger<ElementCreatedEventHandler> _logger;

          public ElementCreatedEventHandler(ILogger<ElementCreatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(ElementCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Element.DomainEvents;

               _logger.LogInformation($"Element Created Event: {domainEvent.GetType().Name} succeeded for Element with Title: {notification.Element.Title} and Id: {notification.Element.Id}");

               return Task.CompletedTask;
          }
     }
}
