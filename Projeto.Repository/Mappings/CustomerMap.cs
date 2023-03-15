using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Model;

namespace Projeto.Repository.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
        
            builder.Property(c => c.Id)
                .HasColumnName("idCustomer")
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
               .HasColumnName("DateOfBirth")
               .IsRequired();
        }
    }
}

