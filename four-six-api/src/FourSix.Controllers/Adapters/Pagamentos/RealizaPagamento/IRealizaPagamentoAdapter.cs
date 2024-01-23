namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoAdapter
    {
        Task Realizar(RealizaPagamentoRequest request);
    }
}
