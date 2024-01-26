using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.CancelaPagamento
{
    public class CancelaPagamentoAdapter : ICancelaPagamentoAdapter
    {
        private readonly Notification _notification;

        private readonly ICancelaPagamentoUseCase _useCase;

        public CancelaPagamentoAdapter(Notification notification,
            ICancelaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancelaPagamentoResponse))]
        public async Task<CancelaPagamentoResponse> Cancelar(CancelaPagamentoRequest request)
        {
            var model = new PagamentoModel(await _useCase.Execute(request.PagamentoId));

            return new CancelaPagamentoResponse(model);
        }
    }
}
