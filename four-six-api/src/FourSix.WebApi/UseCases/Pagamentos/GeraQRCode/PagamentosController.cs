using FourSix.Application.Services;
using FourSix.Application.UseCases;
using FourSix.Application.UseCases.Pagamentos.GeraQRCode;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.GeraQRCode
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Gerar, Efetuar e Cancelar Pagamento")]
    public class PagamentosController : Controller, IOutputPort<string>
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IGeraQRCodeUseCase _useCase;

        public PagamentosController(Notification notification,
            IGeraQRCodeUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        void IOutputPort<string>.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort<string>.NotFound() => _viewModel = NotFound();

        void IOutputPort<string>.Ok(string pedido) =>
            _viewModel = Ok(new GeraQRCodeResponse(pedido));

        void IOutputPort<string>.Exist() => _viewModel = BadRequest("Pedido já existe");

        /// <summary>
        /// Gera novo QRCode
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeraQRCodeResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeraQRCodeResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Gerar([FromBody] GeraQRCodeRequest request)
        {
            _useCase.SetOutputPort(this);

            await _useCase.Execute(request.PedidoId, request.ValorPedido)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
