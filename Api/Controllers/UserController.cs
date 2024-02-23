using Api.Models;
using Api.Token;
using Api.Utils;
using Application.Applications;
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
        private readonly IConfiguration _configuration;

        public UserController(IApplicationUser applicationUser, IConfiguration configuration)
        {
            _applicationUser = applicationUser;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login) 
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
                return Unauthorized();

            var UserExists = await _applicationUser.UserExists(login.UserName, login.Password.ToSHA1());
            if (UserExists) 
            {
                var idUser = await _applicationUser.GetIdUser(login.UserName);

                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create(_configuration.GetSection("Jwt")["SecretKey"]))
                    .AddSubject("Empresa - Info Trapichao")
                    .AddIssuer("Teste.Security.Bearer")
                    .AddAudience("Teste.Security.Bearer")
                    .AddClaim("idUser", idUser)
                    .AddExpiry(5)
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
        [HttpPost("/api/AddUser")]
        public async Task<IActionResult> AddUser([FromBody] Login login)
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
                return Ok("Faltando dados!!!");

            login.Password = login.Password.ToSHA1();

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
