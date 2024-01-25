using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    //[SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class RealizaPagamentoAdapter : IRealizaPagamentoAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IRealizaPagamentoUseCase _useCase;

        public RealizaPagamentoAdapter(Notification notification,
            IRealizaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        ///// <summary>
        ///// Efetiva pagamento pendente
        ///// </summary>
        ///// <param name="request">Dados do pagamento</param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpPut("efetivacoes")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RealizaPagamentoResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RealizaPagamentoResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task Efetivar(RealizaPagamentoRequest request)
        {
            await _useCase.Execute(request.PagamentoId, request.ValorPago)
                .ConfigureAwait(false);

            //return _viewModel!;
        }
    }
}
