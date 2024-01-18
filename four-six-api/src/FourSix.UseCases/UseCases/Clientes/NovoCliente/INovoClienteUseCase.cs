namespace FourSix.UseCases.UseCases.Clientes.NovoCliente
{
    public interface INovoClienteUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(string cpf, string nomeCompleto, string email);
    }
}
