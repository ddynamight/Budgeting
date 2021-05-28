using Budgeting.Presentation.Budgets.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Budgets.Validators
{
     public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
     {
          public CreateBudgetCommandValidator()
          {
               RuleFor(a => a.Year).NotNull().WithMessage("Year Property Cannot be Null").NotEmpty()
                    .WithMessage("Name Property Cannot be Empty").Must(e => e.Length >= 5)
                    .WithMessage("Name Cannot be less than 5 characters");

               //ToDo: Set Other Rules Here

          }
     }
}
