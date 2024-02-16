using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.IServices;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class ApplicationPet : IApplicationPet
    {
        IPet _pet;
        IServicePet _servicePet;
        public ApplicationPet(IPet pet, IServicePet servicePet) 
        {
            _pet = pet;
            _servicePet = servicePet;
        }
        public async Task Add(Pet pet)
        {
            await _pet.Add(pet);
        }

        public async Task AddPet(Pet pet)
        {
            await _servicePet.AddPet(pet);
        }

        public async Task Delete(Pet obj)
        {
            await _pet.Delete(obj);
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _pet.GetAll();
        }

        public async Task<Pet> GetById(int id)
        {
            return await _pet.GetById(id);
        }

        public async Task Update(Pet pet)
        {
            await _pet.Update(pet);
        }

        public async Task UpdatePet(Pet pet)
        {
            await _servicePet.UpdatePet(pet);
        }
    }
}
