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

        public async Task<List<CurrencyLoggingModel>> GetCurrencyLogs(DateTime fromDate, DateTime toDate, Guid sourceCurrencyId, Guid targetCurrencyId)
        {
            var currencyLogsList = new List<CurrencyLoggingModel>();

            var currencyLogsEntity = await _currencyLoggingRepository.GetCurrencyLogs(
                c => c.SourceCurrencyId == sourceCurrencyId && 
                c.TargetCurrencyId == targetCurrencyId &&
                c.DateLogged >= fromDate &&
                c.DateLogged < toDate
            );

            foreach (var currencyLogItem in currencyLogsEntity)
            {
                currencyLogsList.Add(new CurrencyLoggingModel
                {
                    Amount = currencyLogItem.Amount,
                    DateLogged = currencyLogItem.DateLogged,
                    Rate = currencyLogItem.Rate,
                    SourceCurrency = currencyLogItem.SourceCurrency.CurrencyName,
                    TargetCurrency = currencyLogItem.TargetCurrency.CurrencyName,
                    ConvertedAmount = currencyLogItem.ConvertedAmount
                });
            }

            return currencyLogsList;
        }
    }
}
