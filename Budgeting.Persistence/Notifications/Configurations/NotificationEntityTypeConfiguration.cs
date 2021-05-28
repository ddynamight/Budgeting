using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Budgeting.Domain.Notifications;

namespace Budgeting.Persistence.Notifications.Configurations
{
     public class NotificationEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
     {
          public void Configure(EntityTypeBuilder<Notification> builder)
          {
               builder.ToTable("Notifications");

               builder.HasKey(n => n.Id);
               builder.Ignore(n => n.DomainEvents);

               builder.Property(n => n.RowVersion)
                    .IsRowVersion();
          }
     }
}