using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using System;

namespace Budgeting.Presentation.Budgets.Queries
{
     public class GetBudgetQuery : IRequest<GetBudgetQueryResult>
     {
          public Guid Id { get; set; }
     }
}