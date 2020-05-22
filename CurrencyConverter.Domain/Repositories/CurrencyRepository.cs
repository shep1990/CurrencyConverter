using CurrencyConverter.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CurrencyEntity>> GetAsync()
        {
            var currencyList = await _unitOfWork.Context.Set<CurrencyEntity>().ToListAsync();

            return currencyList;
        }
    }
}
