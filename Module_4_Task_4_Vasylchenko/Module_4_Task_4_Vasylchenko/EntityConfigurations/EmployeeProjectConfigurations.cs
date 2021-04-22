using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class EmployeeProjectConfigurations : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("EmployeeProjectId");
            builder.Property(p => p.Rate).HasColumnName("Rate").HasColumnType("money");
            builder.Property(p => p.StartedDate).HasColumnName("StartedDate").HasColumnType("datetime2(7)");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Project)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
