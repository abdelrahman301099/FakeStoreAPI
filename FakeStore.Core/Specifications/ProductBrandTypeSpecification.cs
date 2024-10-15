using FakeStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Core.Specifications
{
    public class ProductBrandTypeSpecification:BaseSpecifications<Product>
    {
        //CTOP which used to get all products 
        public ProductBrandTypeSpecification() : base()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }

        public ProductBrandTypeSpecification(int id) : base(p=> p.Id == id )
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
