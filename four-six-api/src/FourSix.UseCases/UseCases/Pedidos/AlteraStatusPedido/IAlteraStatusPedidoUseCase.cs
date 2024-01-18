using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.UseCases.UseCases.Pedidos.AlteraStatusPedido
{
    public interface IAlteraStatusPedidoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid pedidoId, EnumStatusPedido statusId, DateTime dataStatus);
    }
}
