namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoAdapter
    {
        Task<RealizaPagamentoResponse> Efetivar(RealizaPagamentoRequest request);
    }
}
