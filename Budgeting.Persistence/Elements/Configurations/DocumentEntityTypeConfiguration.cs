using Budgeting.Domain.Elements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Budgeting.Persistence.Elements.Configurations
{
     public class DocumentEntityTypeConfiguration : IEntityTypeConfiguration<Document>
     {
          public void Configure(EntityTypeBuilder<Document> builder)
          {
               builder.ToTable("Documents");

               builder.HasKey(n => n.Id);
               builder.Ignore(n => n.DomainEvents);

               builder.Property(n => n.RowVersion)
                    .IsRowVersion();
          }

     }
}