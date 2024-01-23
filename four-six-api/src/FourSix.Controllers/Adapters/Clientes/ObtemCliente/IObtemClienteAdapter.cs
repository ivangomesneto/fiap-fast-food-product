namespace FourSix.Controllers.Adapters.Clientes.ObtemCliente
{
    public interface IObtemClienteAdapter
    {
        Task Get(string cpf);
    }
}
