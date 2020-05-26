using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CurrencyConverter.Domain.Data
{
    public class CurrencyLoggingEntity
    {
        public Guid Id { get; set; }

        public Guid SourceCurrencyId { get; set; }

        public Guid TargetCurrencyId { get; set; }

        public double Amount { get; set; }

        public double Rate { get; set; }

        public string ConvertedAmount { get; set; }

        public DateTime DateLogged { get; set; }

        public virtual CurrencyEntity SourceCurrency { get; set; }

        public virtual CurrencyEntity TargetCurrency { get; set; }
    }
}
