using System.Collections.Generic;

namespace business.classes
{
    public class Produto : BaseModel
    {
        public int LojaId { get; set; }
        public virtual Loja Loja { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<ItemPedido> Itens { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
