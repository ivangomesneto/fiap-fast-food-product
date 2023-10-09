namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class PedidoItem
    {
        public PedidoItem(Produto itemPedido, decimal precoUnitario, int quantidade, string? observacao)
        {
            ItemPedido = itemPedido;
            ValorUnitario = precoUnitario;
            Quantidade = quantidade;
            Observacao = observacao;
        }

        public Produto ItemPedido { get; }
        public decimal ValorUnitario { get; }
        public int Quantidade { get; private set; }
        public string? Observacao { get; }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
