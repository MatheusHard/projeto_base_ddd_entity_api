using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser
    {
        Task <bool> AddUser(string username, string password, string telefone, TipoUsuario tipoUsuario);
        Task<string> GetIdUser(string username);
        Task<bool> UserExists(string username, string password);

    }
}
