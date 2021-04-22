using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_4_Vasylchenko.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_4_Task_4_Vasylchenko.EntityConfigurations
{
    public class ClientConfigurations : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ClientId");
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50);
            builder.Property(p => p.Country).HasColumnName("Country").HasMaxLength(50);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(150);
        }
    }
}
