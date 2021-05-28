using Budgeting.Presentation.Elements.Commands;
using FluentValidation;

namespace Budgeting.Presentation.Elements.Validators
{
     public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
     {
          public CreateDocumentCommandValidator()
          {
               RuleFor(e => e.Name);
          }
     }
}
