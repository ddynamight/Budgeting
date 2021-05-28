using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
     {
          public UpdateDocumentCommandValidator()
          {
               RuleFor(e => e.Name);
          }
     }
}