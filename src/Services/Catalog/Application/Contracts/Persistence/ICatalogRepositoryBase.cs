using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICatalogRepositoryBase<T> where T:CatalogEntity
    {
        Task<IEnumerable<T>> GetProducts();
        Task<T> GetProduct(int id);
        Task<IEnumerable<T>> GetProductByName(string name);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
