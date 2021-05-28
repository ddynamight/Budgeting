using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class ElementAccessedEventHandler : INotificationHandler<ElementAccessedEvent>
     {
          private readonly ILogger<ElementAccessedEventHandler> _logger;

          public ElementAccessedEventHandler(ILogger<ElementAccessedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(ElementAccessedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Element.DomainEvents;

               _logger.LogInformation($"Element Accessed Event: {domainEvent.GetType().Name} succeeded for Element with Title: {notification.Element.Title} and Id: {notification.Element.Id}");

               return Task.CompletedTask;
          }
     }
}