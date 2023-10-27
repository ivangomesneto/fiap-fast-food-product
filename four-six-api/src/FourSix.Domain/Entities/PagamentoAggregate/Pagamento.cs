using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Domain.Entities.PagamentoAggregate
{
    public class Pagamento : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Pagamento()
        {
        }

        public Pagamento(Guid pedidoId, string codigoQR, EnumStatusPagamento statusId, decimal valorPedido, decimal desconto, decimal valorTotal, decimal valorPago)
        {
            PedidoId = pedidoId;
            CodigoQR = codigoQR;
            StatusId = statusId;
            ValorPedido = valorPedido;
            Desconto = desconto;
            ValorTotal = valorTotal;
            ValorPago = valorPago;
        }

        public Guid PedidoId { get; set; }
        public string CodigoQR { get; set; }
        public EnumStatusPagamento StatusId { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }

        public Pedido Pedido { get; set; }
        public StatusPagamento Status { get; set; }
    }
}
