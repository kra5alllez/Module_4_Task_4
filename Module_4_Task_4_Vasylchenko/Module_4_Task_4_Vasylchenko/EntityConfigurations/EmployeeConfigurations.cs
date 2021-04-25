using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("EmployeeId");
            builder.Property(p => p.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.HiredDate).IsRequired().HasColumnName("HiredDate").HasColumnType("datetime2(7)");
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");

            builder.HasOne(d => d.Office)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Title)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
