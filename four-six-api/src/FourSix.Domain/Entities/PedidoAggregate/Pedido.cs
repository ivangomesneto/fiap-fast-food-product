
using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class Pedido : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Pedido() { }         
        public Pedido(Guid id, string numeroPedido, Guid clienteId, DateTime dataPedido)
        {
            Id = id;
            NumeroPedido = numeroPedido;
            ClienteId = clienteId;
            DataPedido = dataPedido;
        }

        public string NumeroPedido { get; }
        public Guid ClienteId { get; }

        public DateTime DataPedido { get; }

        private readonly List<PedidoItem> _pedidoItens;

        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens.AsReadOnly();
        public int TotalItens => _pedidoItens.Sum(i => i.Quantidade);

        public void AdicionarItem(Produto produto, decimal valorUnitario, int quantidade = 1, string? observacao = null)
        {
            if (!PedidoItens.Any(i => i.ItemPedido.Id == produto.Id))
            {
                _pedidoItens.Add(new PedidoItem(Id, produto.Id, valorUnitario, quantidade, observacao));
                return;
            }
            var itemExistente = PedidoItens.First(i => i.ItemPedido.Id == produto.Id);
            itemExistente.AdicionarQuantidade(quantidade);
        }

        public decimal ValorTotal => _pedidoItens.Sum(i => i.ValorUnitario * i.Quantidade);
        public Cliente Cliente { get; set; }

    }

}
