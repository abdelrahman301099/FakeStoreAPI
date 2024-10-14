using FakeStore.Core.Models;
using FakeStore.Repository.Data.Configrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Repository.Data
{
    public class FakeStoreDbContext:DbContext
    {
        public FakeStoreDbContext( DbContextOptions<FakeStoreDbContext> dbContextOptions):base(dbContextOptions) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfig()); ;
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//كدا هايشوف كل الكلاسييس الل معمولها كونفيجراشن 

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand>  ProductBrands { get; set; }
        public DbSet<ProductType>  ProductTypes { get; set; }
    }
}
