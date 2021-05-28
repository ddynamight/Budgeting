using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Budgets;
using Budgeting.Domain.Elements;
using Budgeting.Domain.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Budgeting.Domain.Users;

namespace Budgeting.Persistence.Contexts
{
     public class AppDbContext : DbContext, IAppDbContext
     {
          public AppDbContext()
          {
          }

          public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

          public static AppDbContext Create()
          {
               return new AppDbContext();
          }

          public DbSet<Budget> Budgets { get; set; }
          public DbSet<Document> Documents { get; set; }
          public DbSet<Element> Elements { get; set; }
          public DbSet<Notification> Notifications { get; set; }
          public DbSet<Setting> Settings { get; set; }


          public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await base.SaveChangesAsync(cancellationToken);
               return result;
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

               base.OnModelCreating(modelBuilder);
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
               IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{envName}.json", optional: true)
                    .Build();
               optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
          }

          /*
          private async Task DispatchEvents()
          {
               var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished);

               foreach (var domainEvent in domainEventEntities)
               {
                    domainEvent.IsPublished = true;
                    await _domainEventService.Publish(domainEvent);
               }
          }
          */
     }
}
