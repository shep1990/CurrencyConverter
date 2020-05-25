using CurrencyConverter.Domain.Data;
using CurrencyConverter.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Services
{
    public interface ICurrencyService
    {
        Task<List<CurrencyEntity>> GetCurrencies();
    }
}
