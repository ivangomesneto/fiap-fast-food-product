using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
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
    public class PagamentosController : Controller
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

        /// <summary>
        /// Gera novo QRCode
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("qrcodes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeraQRCodeResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeraQRCodeResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Gerar([FromBody] GeraQRCodeRequest request)
        {
            await _useCase.Execute(request.PedidoId, request.ValorPedido)
                .ConfigureAwait(false);

            return _viewModel!;
        }
    }
}
