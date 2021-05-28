using Budgeting.Domain.Budgets;
using Budgeting.Domain.Elements;
using Budgeting.Domain.Notifications;
using Budgeting.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Application.Interfaces.Persistence
{
     public interface IAppDbContext
     {

          DbSet<Budget> Budgets { get; set; }
          DbSet<Document> Documents { get; set; }
          DbSet<Element> Elements { get; set; }
          DbSet<Notification> Notifications { get; set; }
          DbSet<Setting> Settings { get; set; }


          Task<int> SaveChangesAsync(CancellationToken cancellationToken);
     }
}
