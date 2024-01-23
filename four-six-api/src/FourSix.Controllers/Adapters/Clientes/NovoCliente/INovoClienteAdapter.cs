namespace FourSix.Controllers.Adapters.Clientes.NovoCliente
{
    public interface INovoClienteAdapter
    {
        Task Inserir(NovoClienteRequest cliente);
    }
}
