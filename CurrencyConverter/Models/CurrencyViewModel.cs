using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class CurrencyViewModel
    {
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public Guid CurrencyTypeId { get; set; }

        public SelectList CurrencyTypes { get; set; }

    }
}
