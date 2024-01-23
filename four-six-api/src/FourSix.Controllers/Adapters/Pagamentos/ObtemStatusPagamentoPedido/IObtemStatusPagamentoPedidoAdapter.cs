namespace FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido
{
    public interface IObtemStatusPagamentoPedidoAdapter
    {
        Task<ObtemStatusPagamentoPedidoPresenter> ObterStatusPagamento(Guid pedidoId);
    }
}
