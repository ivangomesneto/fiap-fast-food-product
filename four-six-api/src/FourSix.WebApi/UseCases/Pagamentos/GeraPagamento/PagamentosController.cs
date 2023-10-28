using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pagamentos.CancelaPagamento;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.UseCases.Pagamentos.CancelaPagamento;
using FourSix.WebApi.UseCases.Pagamentos.RealizaPagamento;
using FourSix.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.GeraPagamento
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller, IOutputPort<Pagamento>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly ICancelaPagamentoUseCase _useCase;

        public PagamentosController(Notification notification,
            ICancelaPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        void IOutputPort<Pagamento>.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort<Pagamento>.NotFound() => _viewModel = NotFound();

        void IOutputPort<Pagamento>.Ok(Pagamento pagamento) =>
            _viewModel = Ok(new GeraPagamentoResponse(new PagamentoModel(pagamento)));

        void IOutputPort<Pagamento>.Exist() => _viewModel = BadRequest("Pagamento já existe");

        /// <summary>
        /// Cancela pagamento
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeraPagamentoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeraPagamentoResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Gerar([FromBody] CancelaPagamentoRequest request)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(request.PagamentoId)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
