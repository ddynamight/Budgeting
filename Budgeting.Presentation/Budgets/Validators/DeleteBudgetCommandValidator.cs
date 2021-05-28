using Budgeting.Presentation.Budgets.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Budgets.Validators
{
     public class DeleteBudgetCommandValidator : AbstractValidator<DeleteBudgetCommand>
     {
          public DeleteBudgetCommandValidator()
          {
               RuleFor(e => e.Id);
          }
     }
}
