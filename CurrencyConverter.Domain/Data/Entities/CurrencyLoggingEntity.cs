using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CurrencyConverter.Domain.Data
{
    public class CurrencyLoggingEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CurrencyId { get; set; }

        public decimal Amount { get; set; }

        public virtual UserEntity User { get; set; }


        public virtual CurrencyEntity Currency { get; set; }
    }
}
