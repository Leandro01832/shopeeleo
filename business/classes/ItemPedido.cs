﻿namespace business.classes
{
    public class ItemPedido : BaseModel
    {
        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public decimal PrecoUnitario { get; set; }

        public void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }

        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
