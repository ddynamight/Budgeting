using Budgeting.Domain.Budgets;
using MediatR;

namespace Budgeting.Domain.Events.Budgets
{
     public class BudgetCreatedEvent : INotification
     {
          public BudgetCreatedEvent(Budget budget)
          {
               Budget = budget;
          }

          public Budget Budget { get; }
     }
}
