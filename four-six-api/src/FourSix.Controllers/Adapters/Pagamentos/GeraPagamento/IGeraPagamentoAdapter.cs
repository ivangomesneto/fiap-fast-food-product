namespace FourSix.Controllers.Adapters.Pagamentos.GeraPagamento
{
    public interface IGeraPagamentoAdapter
    {
        Task Gerar(GeraPagamentoRequest request);
    }
}
