using CurrencyConverter.Domain.Data;
using CurrencyConverter.Domain.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;

namespace CurrencyConverter.Domain
{
    public class CurrencyConverterDbContext : DbContext
    {
        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CurrencyLoggingEntity> CurrencyLogs { get; set; }

        public CurrencyConverterDbContext(DbContextOptions<CurrencyConverterDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CurrencyEntityConfigurations());
            builder.ApplyConfiguration(new UserEntityConfigurations());
            builder.ApplyConfiguration(new CurrencyLoggingEntityConfigurations());
        }
    }
}
