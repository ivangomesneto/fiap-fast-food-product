using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.WebhookPagamento
{
    public interface IWebhookPagamentoUseCase
    {
        Task<Pagamento> Execute(Guid pagamentoId, EnumStatusPagamento statusId);
    }
}
