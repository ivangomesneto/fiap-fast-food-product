using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.NegaPagamento
{
    public class NegaPagamentoUseCase : INegaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public NegaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public Task<Pagamento> Execute(Guid pedidoId) =>
            NegaPagamento(pedidoId);

        private async Task<Pagamento> NegaPagamento(Guid pagamentoId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Negar();

            return pagamento;
        }
    }
}
