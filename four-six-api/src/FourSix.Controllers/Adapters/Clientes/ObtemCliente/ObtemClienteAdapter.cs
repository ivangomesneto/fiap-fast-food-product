using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Clientes.ObtemCliente;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FourSix.Controllers.Adapters.Clientes.ObtemCliente
{
    //[ApiController]
    //[Route("[controller]")]
    //[Produces("application/json")]
    public class ObtemClienteAdapter : IObtemClienteAdapter
    {
        private readonly Notification _notification;

        private IActionResult _viewModel;
        private readonly IObtemClienteUseCase _useCase;

        public ObtemClienteAdapter(Notification notification,
            IObtemClienteUseCase useCase)
        {
            this._useCase = useCase;
            this._notification = notification;
        }

        ///// <summary>
        ///// Obtém cliente
        ///// </summary>
        ///// <param name="cpf"></param>
        ///// <returns></returns>
        //[AllowAnonymous]
        //[HttpGet("{cpf}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemClienteResponse))]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ObtemClienteResponse))]
        //[ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task Get(string cpf)
        {
            await _useCase.Execute(cpf)
                .ConfigureAwait(false);

            //return this._viewModel!;
        }
    }
}
