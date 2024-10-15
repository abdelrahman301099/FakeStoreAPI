using FakeStore.Core.Models;
using FakeStore.Core.Repositories;
using FakeStore.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly FakeStoreDbContext _dbContext;
        public GenericRepository(FakeStoreDbContext dbContext)//Ask CLR to create object from the context Implicitly
        {
            _dbContext = dbContext;
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {

            //return await _dbContext.Set<T>().Where(x=> x.Id == id).FirstOrDefaultAsync();

            return await _dbContext.Set<T>().FindAsync(id);//Search Localy First
        }
    }
}
