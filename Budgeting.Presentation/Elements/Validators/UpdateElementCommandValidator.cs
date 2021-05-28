using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class UpdateElementCommandValidator : AbstractValidator<UpdateElementCommand>
     {
          public UpdateElementCommandValidator()
          {
               RuleFor(e => e.Title);
          }
     }
}
