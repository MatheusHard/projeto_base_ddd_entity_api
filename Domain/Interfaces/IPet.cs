using Domain.Interfaces.Generics;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPet : IGenerics<Pet>
    {
        Task<List<Pet>> GetAll(Expression<Func<Pet, bool>> predicate);
    }
}
