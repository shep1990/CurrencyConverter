using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace CurrencyConverter.Models
{
    public class CurrencyViewModel
    {
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public Guid SourceCurrencyId { get; set; }
        public Guid TargetCurrencyId { get; set; }

        public SelectList CurrencyTypes { get; set; }

    }
}
