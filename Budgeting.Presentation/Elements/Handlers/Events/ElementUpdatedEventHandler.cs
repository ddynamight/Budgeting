using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class ElementUpdatedEventHandler : INotificationHandler<ElementUpdatedEvent>
     {
          private readonly ILogger<ElementUpdatedEventHandler> _logger;

          public ElementUpdatedEventHandler(ILogger<ElementUpdatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(ElementUpdatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Element.DomainEvents;

               _logger.LogInformation($"Element Updated Event: {domainEvent.GetType().Name} succeeded for Element with Title: {notification.Element.Title} and Id: {notification.Element.Id}");

               return Task.CompletedTask;
          }

     }
}