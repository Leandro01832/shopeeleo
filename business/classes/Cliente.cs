using business.Join;
using System.Collections.Generic;

namespace business.classes
{
    public class Cliente : Pessoa
    {
        public virtual List<LojaCliente> Clientes { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
