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

        public Task<StatusPagamento> Execute(Guid pedidoId) => ObterStatusPagamento(pedidoId);

        private async Task<StatusPagamento> ObterStatusPagamento(Guid pedidoId)
        {
            var statusPagamento = new StatusPagamento();
                //this._pagamentoRepository.Listar(l => l.PedidoId == pedidoId).Select(s => s.StatusId).First();

            return statusPagamento;
        }
    }
}