namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class PedidoItem
    {
        public PedidoItem(Produto itemPedido, Guid pedidoId, decimal precoUnitario, int quantidade, string? observacao)
        {
            PedidoId = pedidoId;
            ItemPedido = itemPedido;
            ValorUnitario = precoUnitario;
            Quantidade = quantidade;
            Observacao = observacao;
        }

        public Guid PedidoId { get; set; }
        public Guid ItemPedidoId { get; set; }
        public decimal ValorUnitario { get; }
        public int Quantidade { get; private set; }
        public string? Observacao { get; }

        //public Pedido Pedido { get; set; }
        public Produto ItemPedido { get; }


        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
