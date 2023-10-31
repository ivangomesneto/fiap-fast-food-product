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

        public Guid PedidoId { get; }
        public string CodigoQR { get; }
        public EnumStatusPagamento StatusId { get; private set; }
        public decimal ValorPedido { get; }
        public decimal Desconto { get; }
        public decimal ValorTotal { get; }
        public decimal ValorPago { get; private set; }

        public Pedido Pedido { get; set; }
        public StatusPagamento Status { get; set; }

        public void Pagar(decimal valorPago)
        {
            ValorPago = valorPago;
            StatusId = EnumStatusPagamento.Pago;
        }

        public void Cancelar()
        {
            ValorPago = 0;
            StatusId = EnumStatusPagamento.Cancelado;
        }
    }
}
