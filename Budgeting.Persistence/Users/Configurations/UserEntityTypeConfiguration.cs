using Budgeting.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeting.Persistence.Users.Configurations
{
     public class UserEntityTypeConfiguration : IEntityTypeConfiguration<AppUser>
     {
          public void Configure(EntityTypeBuilder<AppUser> builder)
          {
               builder.ToTable("AppUser");

               builder.HasKey(a => a.Id);
               builder.Ignore(a => a.DomainEvents);

               

               // One to Many Relationships Configurations

               builder.HasMany(a => a.Notifications)
                    .WithOne(n => n.AppUser)
                    .HasForeignKey(n => n.AppUserId);
          }
     }
}