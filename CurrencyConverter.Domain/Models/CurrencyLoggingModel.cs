using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Models
{
    public class CurrencyLoggingModel
    {
        public Guid SourceCurrencyId { get; set; }

        public Guid TargetCurrencyId { get; set; }

        public double Amount { get; set; }

        public double Rate { get; set; }

        public DateTime DateLogged { get; set; }
    }
}
