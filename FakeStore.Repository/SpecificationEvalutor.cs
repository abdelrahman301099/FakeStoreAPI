using FakeStore.Core.Models;
using FakeStore.Core.Spacifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Repository
{
    public static class SpecificationEvalutor<T> where T : BaseEntity
    {
        //Function To build Queries Dynamically
        public static IQueryable<T> GetQyery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var Query = inputQuery; //_dbContext.Set<T>();
            if(specification.Criateria is not null)
            {
                Query = Query.Where(specification.Criateria);//_dbContext.Set<T>().Where(p=> p.Id = id);

            }
            Query = specification.Includes
                   .Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));

            //_dbContext.Set<T>().Where(p=> p.Id = id).Include(p=> p.ProductId).Include(p=> p.ProductType);
            return Query;
        }
    }
}
