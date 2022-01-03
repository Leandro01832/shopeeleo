using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {

        }

        public Pedido(string clienteId)
        {
            ClienteId = clienteId;
            Cadastro = new Cadastro();
        }

        //TAREFA 02: CRIAR CONSTRUTOR COM ID DO CLIENTE

        //TAREFA 03: ADICIONAR MIGRAÇÃO
        //TAREFA 04: APLICAR MIGRAÇÃO

        public Pedido(string clienteId, Cadastro cadastro)
        {
            ClienteId = clienteId;
            Cadastro = cadastro;
        }

        public List<ItemPedido> ItensPedido { get; private set; } = new List<ItemPedido>();

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        [Required]
        public virtual Cadastro Cadastro { get; private set; }

        //TAREFA 01: ADICIONAR ID DO CLIENTE AO PEDIDO

        [Required]
        public string ClienteId { get; set; }
    }
}
