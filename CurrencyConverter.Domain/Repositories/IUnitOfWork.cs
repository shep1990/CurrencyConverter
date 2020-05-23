using Microsoft.EntityFrameworkCore;
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
