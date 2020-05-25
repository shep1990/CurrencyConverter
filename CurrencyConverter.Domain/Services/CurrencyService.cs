using CurrencyConverter.Domain.Data;
using CurrencyConverter.Domain.Repositories;
using CurrencyConverter.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<List<CurrencyEntity>> GetCurrencies()
        {
            var currencyList = await _currencyRepository.GetAsync();

            return currencyList;
        }
    }
}
