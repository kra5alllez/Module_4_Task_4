using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("ClientId");
            builder.Property(p => p.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.Country).IsRequired().HasColumnName("Country").HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasColumnName("Email").HasMaxLength(150);
        }
    }
}
