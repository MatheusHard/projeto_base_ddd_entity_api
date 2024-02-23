using Api.Models;
using Application.Interfaces;
using Entity.Entities;
using Entity.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IApplicationPet _applicationPet;
        
        public PetController(IApplicationPet applicationPet)
        {
            _applicationPet = applicationPet;
        }   

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AddPet")]
        public async Task<List<Notify>> AddPet(PetModel model)
        {
            var newPet = new Pet();

            newPet.Id = model.Id;
            newPet.Name = model.Name;
            newPet.Idade = model.Idade;
            newPet.UserId = await GetIdUSerIn();

            await _applicationPet.AddPet(newPet);

            return newPet.Notifications;


        }

        private async Task<string> GetIdUSerIn()
        {
            if(User  != null)
            {
                var idUser = User.FindFirst("idUser");
                return idUser.Value;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
