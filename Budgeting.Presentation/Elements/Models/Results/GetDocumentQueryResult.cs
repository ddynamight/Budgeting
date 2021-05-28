using System;

namespace Budgeting.Presentation.Elements.Models.Results
{
     public class GetDocumentQueryResult
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public string Url { get; set; }
          public DateTime Date { get; set; }
          public Guid ElementId { get; set; }
     }
}
