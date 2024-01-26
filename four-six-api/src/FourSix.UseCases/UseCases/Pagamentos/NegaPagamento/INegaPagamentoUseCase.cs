using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.NegaPagamento
{
    public interface INegaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Pagamento> Execute(Guid pagamentoId);
    }
}
