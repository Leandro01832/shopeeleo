using System.Collections.Generic;

namespace business.classes
{
    public class Loja : BaseModel
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual List<Cliente> Clientes { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
    }
}
