namespace FourSix.Controllers.Adapters.Pagamentos.CancelaPagamento
{
    public interface ICancelaPagamentoAdapter
    {
        Task Cancelar(CancelaPagamentoRequest request);
    }
}
