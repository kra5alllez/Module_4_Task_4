using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class OfficeConfigurations : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("OfficeId");
            builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(100);
            builder.Property(p => p.Location).HasColumnName("Location").HasMaxLength(100);
        }
    }
}
