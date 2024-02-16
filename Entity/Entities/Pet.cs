using Entity.Entities.Security;
using Entity.Notifications;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Pet : Notify
    {
        public int Id { get; set; }
        
        [MaxLength(255)]
        public string Name { get; set; }

        public int Idade{ get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao{ get; set; }

        [ForeignKey("User")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
