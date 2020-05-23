using CurrencyConverter.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region CurrencySeedData
            builder.Entity<CurrencyEntity>().HasData(
                    new CurrencyEntity { Id = new Guid("2A980CB3-82CF-4B88-88E3-58C486C6D939"), CurrencyName = "GBP" },
                    new CurrencyEntity { Id = new Guid("3132922E-224F-40DF-98D8-CB62CD282E96"), CurrencyName = "USD" },
                    new CurrencyEntity { Id = new Guid("F9EB8CD0-3C14-4480-AA93-0056F51C4EE4"), CurrencyName = "AUD" },
                    new CurrencyEntity { Id = new Guid("2d115204-059a-4018-ae21-d9c53bdad589"), CurrencyName = "EUR" });
            #endregion

        }
    }
}
