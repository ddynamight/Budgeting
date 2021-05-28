using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class DeleteElementCommandValidator : AbstractValidator<DeleteElementCommand>
     {
          public DeleteElementCommandValidator()
          {
               RuleFor(e => e.Id);
          }
     }
}