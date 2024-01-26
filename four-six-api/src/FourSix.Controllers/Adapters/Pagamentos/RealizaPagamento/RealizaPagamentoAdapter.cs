using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoAdapter : IRealizaPagamentoAdapter
    {
        private readonly Notification _notification;

        private readonly IRealizaPagamentoUseCase _useCase;

        public RealizaPagamentoAdapter(Notification notification,
            IRealizaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RealizaPagamentoResponse))]
        public async Task<RealizaPagamentoResponse> Efetivar(RealizaPagamentoRequest request)
        {
            var model = new PagamentoModel(await _useCase.Execute(request.PagamentoId, request.ValorPago));

            return new RealizaPagamentoResponse(model);
        }
    }
}
