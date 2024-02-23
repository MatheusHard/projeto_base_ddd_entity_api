using Entity.Entities.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UserId { get; set; }
        
    }
}
