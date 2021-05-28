using Budgeting.Domain.Budgets;
using MediatR;

namespace Budgeting.Domain.Events.Budgets
{
     public class BudgetUpdatedEvent : INotification
     {
          public BudgetUpdatedEvent(Budget budget)
          {
               Budget = budget;
          }

          public Budget Budget { get; }
     }
}