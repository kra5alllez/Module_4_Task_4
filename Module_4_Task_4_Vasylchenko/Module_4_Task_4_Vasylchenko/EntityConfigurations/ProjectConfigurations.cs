using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ProjectId");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.Budget).HasColumnName("Budget").HasColumnType("money");
            builder.Property(p => p.StartedDate).HasColumnName("StartedDate").HasColumnType("datetime2(7)");
        }
    }
}
