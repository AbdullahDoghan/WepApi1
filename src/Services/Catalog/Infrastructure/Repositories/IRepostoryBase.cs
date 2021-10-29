using Application.Contracts.Persistence;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IRepostoryBase<T> : ICatalogRepositoryBase<T> where T : CatalogEntity
    {
        private readonly CatalogContext _db;

        public IRepostoryBase(CatalogContext db)
        {
            _db = db;
        }

        public async Task<T> AddAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task<T> GetProduct(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<CatalogEntity>> GetProductByName(string name)
        {
            var List = await _db.Catalog.Where(x => x.Name == name).ToListAsync();
            return List;
        }

        public async Task<IReadOnlyList<T>> GetProducts()
        {
            return await _db.Set<T>().ToListAsync();
        }




    }
}
