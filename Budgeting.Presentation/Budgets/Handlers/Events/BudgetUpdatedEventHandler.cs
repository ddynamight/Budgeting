using Budgeting.Domain.Events.Budgets;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Events
{
     public class BudgetUpdatedEventHandler : INotificationHandler<BudgetUpdatedEvent>
     {
          private readonly ILogger<BudgetUpdatedEventHandler> _logger;

          public BudgetUpdatedEventHandler(ILogger<BudgetUpdatedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(BudgetUpdatedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Budget.DomainEvents;

               _logger.LogInformation($"Budget Updated Event: {domainEvent.GetType().Name} succeeded for Budget with Year: {notification.Budget.Year} and Id: {notification.Budget.Id}");

               return Task.CompletedTask;
          }

     }
}