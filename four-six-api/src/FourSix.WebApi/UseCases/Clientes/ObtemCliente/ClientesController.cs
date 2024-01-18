using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Clientes.ObtemCliente;
using FourSix.WebApi.Modules.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.UseCases.Clientes.ObtemCliente
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClientesController : Controller
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemClienteUseCase _useCase;

        public ClientesController(Notification notification,
            IObtemClienteUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        /// <summary>
        /// Obtém cliente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemClienteResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemClienteResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get([FromRoute][Required] string cpf)
        {
            await _useCase.Execute(cpf)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
