using Api.Models;
using Api.Token;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IApplicationUser _applicationUser;

        public UserController(IApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login) 
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
                return Unauthorized();

            var UserExists = await _applicationUser.UserExists(login.UserName, login.Password);
            if (UserExists) 
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678_Testando_Nova_Key_Longa"))
                    .AddSubject("Empresa - Info Trapichao")
                    .AddIssuer("Teste.Security.Bearer")
                    .AddAudience("Teste.Security.Bearer")
                    .AddClaim("UserApiNumero", "1")
                    .AddExpiry(2)
                    .Builder();

                return Ok(token.value);

            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("api/AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Login login)
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
                return Ok("Faltando dados!!!");

            var user = await _applicationUser.AddUser(login.UserName, login.Password, login.Telefone, login.TipoUsuario);

            if (user)
            {
                return Ok("Usuario adicionado com Sucesso!!");
            }
            else
            {
                return Ok("Error ao adicionar Usuario!!");

            }
        }
    }
}
