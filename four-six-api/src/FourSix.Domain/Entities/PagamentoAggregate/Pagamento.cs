using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Domain.Entities.PagamentoAggregate
{
    public class Pagamento : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Pagamento()
        {
        }

        public Pagamento(Guid id, string codigoQR, decimal valor, decimal desconto, decimal valorTotal)
        {
            Id = id;
            CodigoQR = codigoQR;
            Valor = valor;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public Guid PedidoId { get; set; }
        public string CodigoQR { get; set; }
        public EnumStatusPagamento StatusId { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }

        public Pedido Pedido { get; set; }
        public StatusPagamento Status { get; set; }
    }
}
