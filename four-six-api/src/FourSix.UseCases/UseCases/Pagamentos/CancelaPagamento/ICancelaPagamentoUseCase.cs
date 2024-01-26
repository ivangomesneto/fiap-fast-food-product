using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento
{
    public interface ICancelaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Pagamento> Execute(Guid pagamentoId);
    }
}
