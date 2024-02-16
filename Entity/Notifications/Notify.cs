using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Notifications
{
    public class Notify
    {
        [NotMapped]
        public string NomeProp { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notify> Notifications { get; set; }

        public  bool ValidString(string  value, string nomeProp)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nomeProp))
            {
                Notifications.Add(new Notify {  Mensagem = "Campo Obrigatório", NomeProp = nomeProp });
            }
            return true;
        }
    }
}
