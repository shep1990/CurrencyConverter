using CurrencyConverter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Services
{
    public interface ICurrencyLoggingService
    {
        Task<int> AddCurrencyLog(CurrencyLoggingModel model);

        Task<List<CurrencyLoggingModel>> GetCurrencyLogs(DateTime fromDate, DateTime toDate, Guid sourceCurrencyId, Guid targetCurrencyId);
    }
}
