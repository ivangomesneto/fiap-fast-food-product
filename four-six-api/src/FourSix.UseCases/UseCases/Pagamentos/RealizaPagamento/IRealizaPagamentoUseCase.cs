using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Pagamento> Execute(Guid pagamentoId, decimal valorPago);
    }
}
