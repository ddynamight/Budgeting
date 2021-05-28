using Budgeting.Domain.Events.Budgets;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Events
{
     public class BudgetCreatedEventHandler : INotificationHandler<BudgetCreatedEvent>
     {
          private readonly ILogger<BudgetCreatedEventHandler> _logger;

          public BudgetCreatedEventHandler(ILogger<BudgetCreatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(BudgetCreatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Budget.DomainEvents;

               _logger.LogInformation($"Budget Created Event: {domainEvent.GetType().Name} succeeded for Budget with Year: {notification.Budget.Year} and Id: {notification.Budget.Id}");

               return Task.CompletedTask;
          }
     }
}