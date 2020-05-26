using CurrencyConverter.Domain.Data;
using CurrencyConverter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Repositories
{
    public interface ICurrencyLoggingRepository
    {
        Task<int> AddCurrencyLog(CurrencyLoggingModel model);

        Task<List<CurrencyLoggingEntity>> GetCurrencyLogs(Expression<Func<CurrencyLoggingEntity, bool>> predicate);
    }
}
