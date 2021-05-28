using System;

namespace Budgeting.Presentation.Elements.Models.Results
{
     public class DeleteDocumentCommandResult
     {
          public Guid Id { get; set; }
          public bool IsDeleted { get; set; }
          public string Message { get; set; }
     }
}
