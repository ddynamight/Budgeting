using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
     {
          public DeleteDocumentCommandValidator()
          {
               RuleFor(e => e.Id);
          }
     }
}