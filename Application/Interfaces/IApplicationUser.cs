using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationUser 
    {
        Task<bool> AddUser(string username, string password, string telefone, TipoUsuario tipoUsuario);
        Task<bool> UserExists(string username, string password);


    }
}
