using CurrencyConverter.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.EntityConfiguration
{
    public class CurrencyLoggingEntityConfigurations : IEntityTypeConfiguration<CurrencyLoggingEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyLoggingEntity> builder)
        {
            builder.ToTable("CurrencyLogging");

            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            builder.HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(x => x.CurrencyId)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
