namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoAdapter
    {
        Task<ObtemStatusPagamentoPedidoResponse> ObterStatusPagamento(Guid pedidoId);
    }
}
