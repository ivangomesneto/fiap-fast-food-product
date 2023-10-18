using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Clientes.NovoCliente
{
    public class NovoClienteResponse
    {
        public NovoClienteResponse(ClienteModel clienteModel) => this.Cliente = clienteModel;
        public ClienteModel Cliente { get; }
    }
}
