using Application.Interfaces.Generics;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationPet : IGenericsApplication<Pet>
    {
        Task AddPet(Pet pet);
        Task UpdatePet(Pet pet);
        Task<List<Pet>> GetAll();
    }
}
