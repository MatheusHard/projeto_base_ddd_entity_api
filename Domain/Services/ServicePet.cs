using Domain.Interfaces;
using Domain.Interfaces.IServices;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicePet : IServicePet

    {
        private readonly IPet _IPet;

        public ServicePet(IPet IPet) 
        {
            _IPet = IPet;
        }
        public async Task Add(Pet pet)
        {
            var validName = pet.ValidString(pet.Name, "Name");

            if (validName) 
             {
                pet.DataCadastro = DateTime.Now;
                pet.DataAlteracao = DateTime.Now;   
                await _IPet.Add(pet);
            }

        }

        public async Task AddPet(Pet pet)
        {
            var validName = pet.ValidString(pet.Name, "Name");

            if (validName) {
                pet.DataCadastro = DateTime.Now;
                pet.DataAlteracao = DateTime.Now;
                await _IPet.Add(pet);
            }
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _IPet.GetAll(p => p.Idade > 0);
        }

        public async Task Update(Pet pet)
        {
            var validName = pet.ValidString(pet.Name, "Name");

            if (validName) 
            {
                pet.DataAlteracao = DateTime.Now;
                await _IPet.Update(pet);
            }
        }

        public async Task UpdatePet(Pet pet)
        {
            var validName = pet.ValidString(pet.Name, "Name");

            if (validName) {
                pet.DataAlteracao = DateTime.Now;
                await _IPet.Update(pet);
            }
        }
    }
}
