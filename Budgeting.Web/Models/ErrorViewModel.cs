using System;

namespace Budgeting.Web.Models
{
     public class ErrorViewModel
     {
          public string RequestId { get; set; }

          public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
     }
}
