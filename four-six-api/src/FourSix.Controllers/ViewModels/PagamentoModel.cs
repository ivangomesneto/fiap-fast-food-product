using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.WebApi.ViewModels
{
    public class PagamentoModel
    {
        public PagamentoModel(Pagamento pagamento)
        {
            Id = pagamento.Id;
            PedidoId = pagamento.PedidoId;
            CodigoQR = pagamento.CodigoQR;
            StatusId = pagamento.StatusId;
            ValorPedido = pagamento.ValorPedido;
            Desconto = pagamento.Desconto;
            ValorTotal = pagamento.ValorTotal;
            ValorPago = pagamento.ValorPago;
        }
        public Guid Id { get; }
        public Guid PedidoId { get; set; }
        public string CodigoQR { get; set; }
        public EnumStatusPagamento StatusId { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
    }
}
