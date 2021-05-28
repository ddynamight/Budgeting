using Budgeting.Domain.Elements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeting.Persistence.Elements.Configurations
{
     public class ElementEntityTypeConfiguration : IEntityTypeConfiguration<Element>
     {
          public void Configure(EntityTypeBuilder<Element> builder)
          {
               builder.ToTable("Elements");

               builder.HasKey(n => n.Id);
               builder.Ignore(n => n.DomainEvents);

               builder.Property(n => n.RowVersion)
                    .IsRowVersion();


               //One to Many Relationship Configuration
               builder.HasMany(e => e.Documents)
                    .WithOne(d => d.Element)
                    .HasForeignKey(d => d.ElementId);
          }
     }
}