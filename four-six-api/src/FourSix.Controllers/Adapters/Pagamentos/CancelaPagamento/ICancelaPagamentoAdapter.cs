namespace FourSix.Controllers.Adapters.Pagamentos.CancelaPagamento
{
    public interface ICancelaPagamentoAdapter
    {
        Task<CancelaPagamentoResponse> Cancelar(Guid pagamentoId);
    }
}
