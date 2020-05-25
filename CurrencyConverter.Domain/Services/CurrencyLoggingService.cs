using CurrencyConverter.Domain.Models;
using CurrencyConverter.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Services
{
    public class CurrencyLoggingService : ICurrencyLoggingService
    {
        private readonly ICurrencyLoggingRepository _currencyLoggingRepository;

        public CurrencyLoggingService(ICurrencyLoggingRepository currencyLoggingRepository)
        {
            _currencyLoggingRepository = currencyLoggingRepository;
        }

        public async Task<int> AddCurrencyLog(CurrencyLoggingModel model)
        {
            return await _currencyLoggingRepository.AddCurrencyLog(model);
        }
    }
}
