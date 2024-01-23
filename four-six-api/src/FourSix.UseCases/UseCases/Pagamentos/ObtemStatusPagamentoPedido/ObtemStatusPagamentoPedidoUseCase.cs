using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoUseCase : IObtemStatusPagamentoPedidoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public ObtemStatusPagamentoPedidoUseCase(IPagamentoRepository pagamentoRepository)
        {
            this._pagamentoRepository = pagamentoRepository;
        }

        public Task<Pagamento> Execute(Guid pedidoId) => ObterStatusPagamento(pedidoId);

        private async Task<Pagamento> ObterStatusPagamento(Guid pedidoId)
        {
            var pagamento = this._pagamentoRepository.Listar(l => l.PedidoId == pedidoId).FirstOrDefault();

            return pagamento;
        }
    }
}