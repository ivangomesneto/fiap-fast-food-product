using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public interface IOutputPort
    {
        /// <summary>
        /// Novo Pedido
        /// </summary>
        void Ok(Pedido pedido);

        /// <summary>
        /// Pedido não encontrado
        /// </summary>
        void NotFound();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void Invalid();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void Exist();
    }
}
