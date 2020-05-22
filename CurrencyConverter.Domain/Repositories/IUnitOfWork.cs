using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Repositories
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
