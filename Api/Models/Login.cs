using Entity.Enums;

namespace Api.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telefone { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
