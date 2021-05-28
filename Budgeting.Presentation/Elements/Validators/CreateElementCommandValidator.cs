using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class CreateElementCommandValidator : AbstractValidator<CreateElementCommand>
     {
          public CreateElementCommandValidator()
          {
               RuleFor(e => e.Title);
          }
     }
}