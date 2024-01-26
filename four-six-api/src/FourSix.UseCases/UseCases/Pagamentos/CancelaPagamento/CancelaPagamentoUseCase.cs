using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento
{
    public class CancelaPagamentoUseCase : ICancelaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Pagamento> Execute(Guid pedidoId) => CancelarPagamento(pedidoId);

        private async Task<Pagamento> CancelarPagamento(Guid pagamentoId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Cancelar();

            await _unitOfWork.Save();

            return pagamento;
        }
    }
}
