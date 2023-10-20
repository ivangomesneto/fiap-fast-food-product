using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Clientes.ObtemCliente
{
    public class ObtemClienteResponse
    {
        public ObtemClienteResponse(ClienteModel clienteModel) => this.Cliente = clienteModel;
        public ClienteModel Cliente { get; }
    }
}
