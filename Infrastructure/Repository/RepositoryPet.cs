using Domain.Interfaces;
using Entity.Entities;
using Infrastructure.Configs;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryPet : RepositoryGeneric<Pet>, IPet
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;
        public RepositoryPet() 
        {
            _optionsBuilder = new DbContextOptions<Contexto>();
        }  
        public async Task<List<Pet>> GetAll(Expression<Func<Pet, bool>> predicate)
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Pets.Where(predicate).AsNoTracking().ToListAsync();
            }
        }
    }
}
