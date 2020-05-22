using CurrencyConverter.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyEntity>> GetAsync();
    }
}
