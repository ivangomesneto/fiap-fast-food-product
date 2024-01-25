namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoAdapter
    {
        Task Efetivar(RealizaPagamentoRequest request);
    }
}
