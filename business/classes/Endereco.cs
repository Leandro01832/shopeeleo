using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{
    public class Endereco : BaseModel
    {
        [Key, ForeignKey("Cliente")]
        public new int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}