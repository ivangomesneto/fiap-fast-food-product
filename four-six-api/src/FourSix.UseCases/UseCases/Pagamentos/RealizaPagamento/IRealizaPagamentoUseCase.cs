namespace FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid pagamentoId, decimal valorPago);
    }
}
