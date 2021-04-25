using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class TitleConfigurations : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("TitleId");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        }
    }
}
