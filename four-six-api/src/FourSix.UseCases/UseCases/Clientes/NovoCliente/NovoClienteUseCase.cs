using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Clientes.NovoCliente
{
    public class NovoClienteUseCase : INovoClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NovoClienteUseCase(
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork)
        {
            this._clienteRepository = clienteRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public Task Execute(string cpf, string nomeCompleto, string email) =>
            this.NovoCliente(
                new Cliente(Guid.NewGuid(),
                cpf,
                nomeCompleto,
                email));

        private async Task NovoCliente(Cliente cliente)
        {
            if (this._clienteRepository.Listar(q => q.Cpf == cliente.Cpf).Any())
            {
                throw new Exception("Cliente já existe");
            }

            await this._clienteRepository
                 .Incluir(cliente)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
