using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Module_4_Task_4_Vasylchenko.Entities;
using Module_4_Task_4_Vasylchenko.EntityConfigurations;
using System;

namespace Module_4_Task_4_Vasylchenko
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Title> Titles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfigurations());
            modelBuilder.ApplyConfiguration(new OfficeConfigurations());
            modelBuilder.ApplyConfiguration(new ProjectConfigurations());
            modelBuilder.ApplyConfiguration(new TitleConfigurations());
        }
    }
}
