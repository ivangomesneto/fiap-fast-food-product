namespace FourSix.Domain.Entities.ClienteAggregate
{
    public interface IClienteFactory
    {
        Cliente NovoCliente(string cpf, string nome, string email);
    }
}
