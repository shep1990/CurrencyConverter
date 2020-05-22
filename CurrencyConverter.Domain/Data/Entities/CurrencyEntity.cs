using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Data
{
    public class CurrencyEntity
    {
        public Guid Id { get; set; }

        public string CurrencyName { get; set; }
    }
}
