using CurrencyConverter.Domain.Data;
using CurrencyConverter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Repositories
{
    public class CurrencyLoggingRepository : ICurrencyLoggingRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyLoggingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCurrencyLog(CurrencyLoggingModel model)
        {
            var entity = new CurrencyLoggingEntity
            {
                SourceCurrencyId = model.SourceCurrencyId,
                TargetCurrencyId = model.TargetCurrencyId,
                Amount = model.Amount,
                Rate = model.Rate,
                DateLogged = model.DateLogged,
                ConvertedAmount = model.ConvertedAmount
            };

            _unitOfWork.Context.Set<CurrencyLoggingEntity>().Add(entity);

            return await _unitOfWork.CommitAsync();       
        }

        public async Task<List<CurrencyLoggingEntity>> GetCurrencyLogs(Expression<Func<CurrencyLoggingEntity, bool>> predicate)
        {
            var currencyLogList = await _unitOfWork.Context.Set<CurrencyLoggingEntity>()
                .Include(x => x.SourceCurrency)
                .Include(x => x.TargetCurrency)
                .Where(predicate)
                .ToListAsync();

            return currencyLogList;
        }
    }
}
