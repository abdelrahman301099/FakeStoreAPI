using FakeStore.Core.Models;
using FakeStore.Core.Spacifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criateria
        {
            get; set;
        }


        public List<Expression<Func<T, object>>> Includes{get; set;}
            = new List<Expression<Func<T, object>>>();
       

        public BaseSpecifications(){ }

        public BaseSpecifications(Expression<Func<T, bool>> criteriaExpression )
        {
            Criateria = criteriaExpression;
        }
    }
}
