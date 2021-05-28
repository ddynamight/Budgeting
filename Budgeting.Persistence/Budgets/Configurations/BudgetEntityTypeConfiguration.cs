using Budgeting.Domain.Budgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeting.Persistence.Budgets.Configurations
{
     public class BudgetEntityTypeConfiguration : IEntityTypeConfiguration<Budget>
     {
          public void Configure(EntityTypeBuilder<Budget> builder)
          {
               builder.ToTable("Budgets");

               builder.HasKey(n => n.Id);
               builder.Ignore(n => n.DomainEvents);

               builder.Property(n => n.RowVersion)
                    .IsRowVersion();

               //One to Many Relationship Configuration
               builder.HasMany(b => b.Elements)
                    .WithOne(e => e.Budget)
                    .HasForeignKey(e => e.BudgetId);
          }
     }
}