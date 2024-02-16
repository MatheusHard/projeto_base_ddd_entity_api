using Entity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.Security
{
    public class User : IdentityUser
    {
        [Column("Telefone")]
        public string Telefone  { get; set; }

        [Column("TipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
