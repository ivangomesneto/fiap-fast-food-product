using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoUseCase : IRealizaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RealizaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Execute(Guid pedidoId, decimal valorPago) => RealizarPagamento(pedidoId, valorPago);

        private async Task RealizarPagamento(Guid pagamentoId, decimal valorPago)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Pagar(valorPago);

            var resultado = await _unitOfWork.Save();
        }
    }
}
