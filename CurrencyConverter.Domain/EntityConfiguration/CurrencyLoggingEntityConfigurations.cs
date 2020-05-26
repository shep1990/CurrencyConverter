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

            builder.HasOne(x => x.SourceCurrency)
                .WithMany()
                .HasForeignKey(x => x.SourceCurrencyId)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;

            builder.HasOne(x => x.TargetCurrency)
                .WithMany()
                .HasForeignKey(x => x.TargetCurrencyId)
                .Metadata
                .DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
