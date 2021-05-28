using Budgeting.Presentation.Budgets.Models.Results;
using MediatR;
using System.Collections.Generic;

namespace Budgeting.Presentation.Budgets.Queries
{
     public class GetBudgetsQuery : IRequest<List<GetBudgetQueryResult>>
     {
     }
}