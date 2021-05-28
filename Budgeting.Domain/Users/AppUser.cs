using Budgeting.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Budgeting.Domain.Notifications;

namespace Budgeting.Domain.Users
{
     public class AppUser : IdentityUser, IHasDomainEvent
     {
          public string Title { get; set; }
          public string FirstName { get; set; }
          public string MiddleName { get; set; }
          public string LastName { get; set; }
          public string Image { get; set; }
          public string Address { get; set; }
          public string Area { get; set; }
          public string State { get; set; }
          public string Country { get; set; }
          public bool IsLockedOut { get; set; }
          public DateTime LastOnline { get; set; }
          public bool IsVerified { get; set; }
          public bool IsArchived { get; set; }
          public bool Active { get; set; }
          public string ReferralCode { get; set; }
          public string InviteCode { get; set; }

          public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();


          // One AppUser to Many Relationship
          public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
     }
}
