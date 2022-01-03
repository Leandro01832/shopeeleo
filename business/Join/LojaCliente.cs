using business.classes;

namespace business.Join
{
    public class LojaCliente
    {
        public int LojaId { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Loja Loja { get; set; }
    }
}
