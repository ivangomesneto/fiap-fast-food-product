using FourSix.WebApi.Modules.Commons;
using FourSix.WebApi.UseCases.Pagamentos.CancelaPagamento;
using FourSix.WebApi.UseCases.Pagamentos.ConsultaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.UseCases.Pagamentos.ConfirmaPagamento
{

    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [SwaggerTag("WebHook Confirma Pagamento")]
    public class ConfirmaPagamentoController
    {


        /// <summary>
        /// Webhook confirma pagamento
        /// </summary>
        /// <param name="request">Dados do pagamento</param>
        /// <returns></returns>


    }
}
