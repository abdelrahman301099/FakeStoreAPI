using FakeStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FakeStore.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(FakeStoreDbContext dbContext)
        {

            if (!dbContext.Products.Any())
            {
                var BrandsData = File.ReadAllText("../FakeStore.Repository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brands?.Count > 0)
                {

                    foreach (var item in Brands)
                    {
                        await dbContext.Set<ProductBrand>().AddAsync(item);
                    }
                    dbContext.SaveChanges();
                }
            }


            if (!dbContext.ProductTypes.Any())
            {
                var TypesData = File.ReadAllText("../FakeStore.Repository/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (Types?.Count > 0)
                {


                    foreach (var item in Types)
                    {
                        await dbContext.Set<ProductType>().AddAsync(item);
                    }
                    dbContext.SaveChanges();
                }
            }


            if (!dbContext.Products.Any())
            {

                var ProductsData = File.ReadAllText("../FakeStore.Repository/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (Products?.Count > 0)
                {

                    foreach (var item in Products)
                    {
                        await dbContext.Set<Product>().AddAsync(item);
                    }
                    dbContext.SaveChanges();

                }
            }

        }
    }
}
