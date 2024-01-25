using FourSix.Domain.Entities.PagamentoAggregate;
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

        public Task<Pagamento> Execute(Guid pedidoId, decimal valorPago) => RealizarPagamento(pedidoId, valorPago);

        private async Task<Pagamento> RealizarPagamento(Guid pagamentoId, decimal valorPago)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Pagar(valorPago);

            await _unitOfWork.Save();

            return pagamento;
        }
    }
}
