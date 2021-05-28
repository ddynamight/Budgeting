using Budgeting.Domain.Events.Elements;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Events
{
     public class ElementDeletedEventHandler : INotificationHandler<ElementDeletedEvent>
     {
          private readonly ILogger<ElementDeletedEventHandler> _logger;

          public ElementDeletedEventHandler(ILogger<ElementDeletedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(ElementDeletedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Element.DomainEvents;

               _logger.LogInformation($"Element Deleted Event: {domainEvent.GetType().Name} succeeded for Element with Title: {notification.Element.Title} and Id: {notification.Element.Id}");

               return Task.CompletedTask;
          }

     }
}
