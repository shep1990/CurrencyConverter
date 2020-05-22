using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Data
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
