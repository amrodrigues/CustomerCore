using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Projeto.Repository.Context;

namespace Projeto.Repository.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class EquinoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Equinox.Domain.Models.Customer", b =>
            {
                b.Property<Guid>("IdCustomer")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IdCustomer");

                b.Property<DateTime>("DateOfBirth");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                b.HasKey("IdCustomer");

                b.ToTable("Customer");
            });
        }
    }
}
