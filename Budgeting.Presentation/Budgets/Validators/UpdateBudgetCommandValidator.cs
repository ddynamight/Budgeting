using Budgeting.Presentation.Budgets.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Budgets.Validators
{
     public class UpdateBudgetCommandValidator : AbstractValidator<UpdateBudgetCommand>
     {
          public UpdateBudgetCommandValidator()
          {
               RuleFor(e => e.Year);
          }
     }
}
