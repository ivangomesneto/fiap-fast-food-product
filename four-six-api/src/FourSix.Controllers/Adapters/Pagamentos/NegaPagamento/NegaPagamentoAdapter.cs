using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.NegaPagamento
{
    public class NegaPagamentoAdapter : INegaPagamentoAdapter
    {
        private readonly Notification _notification;

        private readonly ICancelaPagamentoUseCase _useCase;

        public NegaPagamentoAdapter(Notification notification,
            ICancelaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NegaPagamentoResponse))]
        public async Task<NegaPagamentoResponse> Negar(Guid pagamentoId)
        {
            var model = new PagamentoModel(await _useCase.Execute(pagamentoId));

            return new NegaPagamentoResponse(model);
        }
    }
}
