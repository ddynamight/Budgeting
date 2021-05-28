using Budgeting.Domain.Events.Budgets;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Budgets.Handlers.Events
{
     public class BudgetDeletedEventHandler : INotificationHandler<BudgetDeletedEvent>
     {
          private readonly ILogger<BudgetDeletedEventHandler> _logger;

          public BudgetDeletedEventHandler(ILogger<BudgetDeletedEventHandler> _logger)
          {
               this._logger = _logger;
          }

          public Task Handle(BudgetDeletedEvent notification, CancellationToken cancellationToken)
          {
               var domainEvent = notification.Budget.DomainEvents;

               _logger.LogInformation($"Budget Deleted Event: {domainEvent.GetType().Name} succeeded for Budget with Year: {notification.Budget.Year} and Id: {notification.Budget.Id}");

               return Task.CompletedTask;
          }

     }
}