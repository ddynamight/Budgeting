using Budgeting.Domain.Budgets;
using MediatR;

namespace Budgeting.Domain.Events.Budgets
{
     public class BudgetDeletedEvent : INotification
     {
          public BudgetDeletedEvent(Budget budget)
          {
               Budget = budget;
          }

          public Budget Budget { get; }

     }
}