using CurrencyConverter.Domain.Data;
using CurrencyConverter.Domain.Models;
using CurrencyConverter.Domain.Repositories;
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

        public async Task<List<CurrencyModel>> GetCurrencies()
        {
            var currencyModelList = new List<CurrencyModel>();

            var currencyList = await _currencyRepository.GetAsync();

            foreach (var currency in currencyList)
            {
                currencyModelList.Add(new CurrencyModel
                {
                    Id = currency.Id,
                    CurrencyName = currency.CurrencyName
                });
            }

            return currencyModelList;
        }
    }
}
