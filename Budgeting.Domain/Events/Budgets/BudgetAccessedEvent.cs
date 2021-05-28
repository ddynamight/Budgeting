using Budgeting.Domain.Budgets;
using MediatR;

namespace Budgeting.Domain.Events.Budgets
{
     public class BudgetAccessedEvent : INotification
     {
          public BudgetAccessedEvent(Budget budget)
          {
               Budget = budget;
          }

          public Budget Budget { get; }
     }
}
