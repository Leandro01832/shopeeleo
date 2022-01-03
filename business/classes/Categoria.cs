using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{
    public class Categoria : BaseModel
    {
        [Key, ForeignKey("Produto")]
        public new int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public string Nome { get; set; }
    }
}