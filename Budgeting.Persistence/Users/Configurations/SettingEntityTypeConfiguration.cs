using Budgeting.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeting.Persistence.Users.Configurations
{
     public class SettingEntityTypeConfiguration : IEntityTypeConfiguration<Setting>
     {
          public void Configure(EntityTypeBuilder<Setting> builder)
          {
               builder.ToTable("Settings");

               builder.HasKey(s => s.AppUserId);
               builder.Ignore(s => s.Id);
               builder.Ignore(s => s.DomainEvents);

               builder.Property(s => s.RowVersion)
                    .IsRowVersion();
          }
     }
}