using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.WebApi.ViewModels
{
    public class PedidoModel
    {
        public PedidoModel(Pedido pedido)
        {
            Id = pedido.Id;
            NumeroPedido = pedido.NumeroPedido;
            ClienteId = pedido.ClienteId;
            DataPedido = pedido.DataPedido;
            TotalItens = pedido.TotalItens;
            ValorTotal = pedido.ValorTotal;
            PedidoItens = pedido.PedidoItens.Select(s => new PedidoItemModel(s)).ToList();
        }

        Guid Id { get; }
        public string NumeroPedido { get; }
        public Guid? ClienteId { get; }
        public DateTime DataPedido { get; }
        public int TotalItens { get; }
        public decimal ValorTotal { get; }
        public List<PedidoItemModel> PedidoItens { get; }
    }
}
