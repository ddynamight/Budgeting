using Budgeting.Domain.Events.Budgets;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Events
{
     public class BudgetAccessedEventHandler : INotificationHandler<BudgetAccessedEvent>
    {
         private readonly ILogger<BudgetAccessedEventHandler> _logger;

         public BudgetAccessedEventHandler(ILogger<BudgetAccessedEventHandler> _logger)
         {
              this._logger = _logger;
         }

         public Task Handle(BudgetAccessedEvent notification, CancellationToken cancellationToken)
         {
              var domainEvent = notification.Budget.DomainEvents;

              _logger.LogInformation($"Budget Accessed Event: {domainEvent.GetType().Name} succeeded for Budget with Year: {notification.Budget.Year} and Id: {notification.Budget.Id}");

              return Task.CompletedTask;
         }
    }
}