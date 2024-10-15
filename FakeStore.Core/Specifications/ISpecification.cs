using FakeStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Core.Spacifications
{

    //The main goal of creating this Interface is Define the Structure of any Query
    public interface ISpecification<T> where T : BaseEntity
    {
        //Signatuer for Propirty for where Condition

        public Expression<Func<T, bool>> Criateria { get; set; }


        //Signatuer for Propirty for List of Iclude
    
        public List<Expression<Func<T, object>>> Includes { get; set; }

    }
}
