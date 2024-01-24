using FourSix.Application.Services;
using FourSix.Application.UseCases.Pagamentos.NegaPagamento;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.NegaPagamentoUseCase

{
    public class NegaPagamentoUseCase : INegaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pagamento> _outputPort;

        public NegaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _outputPort = new NegaPagamentoPresenter();
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pagamento> outputPort) => _outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid pedidoId) =>
            NegaPagamento(pedidoId);

        private async Task NegaPagamento(Guid pagamentoId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Negar();

            var resultado = await _unitOfWork.Save();

            _outputPort?.Ok(pagamento);
        }
    }
}
