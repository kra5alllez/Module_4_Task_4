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
            builder.Property(p => p.Id).IsRequired().HasColumnName("ProjectId");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnName("Budget").HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");

            builder.HasOne(d => d.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
