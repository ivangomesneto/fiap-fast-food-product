namespace FourSix.Controllers.Adapters.Pagamentos.NegaPagamento
{
    public interface INegaPagamentoAdapter
    {
        Task<NegaPagamentoResponse> Negar(Guid pagamentoId);
    }
}
