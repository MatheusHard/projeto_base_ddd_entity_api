using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IServicePet
    {
        Task AddPet(Pet pet);
        Task UpdatePet(Pet pet);
        Task <List<Pet>> GetAll();

    }
}
