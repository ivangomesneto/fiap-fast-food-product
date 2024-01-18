using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Clientes.ObtemCliente
{
    public class ObtemClienteUseCase : IObtemClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ObtemClienteUseCase(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public Task<Cliente> Execute(string cpf) => this.ObtemCliente(cpf);

        private async Task<Cliente> ObtemCliente(string cpf)
        {
            var cliente = this._clienteRepository
                .Listar(q => q.Cpf == cpf).FirstOrDefault();

            if (cliente != null)
            {
                throw new Exception("Cliente não encontrado");
            }

            return cliente;
        }
    }
}