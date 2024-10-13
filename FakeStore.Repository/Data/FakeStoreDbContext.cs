using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Repository.Data
{
    public class FakeStoreDbContext:DbContext
    {
        public FakeStoreDbContext( DbContextOptions<FakeStoreDbContext> dbContextOptions):base(dbContextOptions) 
        {
            
        }

        //public DbSet<Product> MyProperty { get; set; }
    }
}
