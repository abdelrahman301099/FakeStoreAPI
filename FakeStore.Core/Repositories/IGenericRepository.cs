using FakeStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStore.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity // عشلن اضمن ان ال T دي هاتكون حاجه من نوع بيز انتيتي او حاجه بتورث منها و كدا ااكون ضامن ان اي حاجه من دول هاتكون موديل 
    {
        //Get All
        Task<IEnumerable<T>> GetAllAsync();

        //Get By Id
        Task<T> GetByIdAsync(int id);


    }
}
