using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.WebhookPagamento
{
    public class WebhookPagamentoUseCase : IWebhookPagamentoUseCase
    {

        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WebhookPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }


        public Task<Pagamento> Execute(Guid pagamentoId, EnumStatusPagamento statusId) => processWebhook(pagamentoId, statusId);


        private async Task<Pagamento> processWebhook(Guid pagamentoId, EnumStatusPagamento statusId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.AtualizarStatus(statusId);

            await _unitOfWork.Save();

            return pagamento;
        }

    }
}
