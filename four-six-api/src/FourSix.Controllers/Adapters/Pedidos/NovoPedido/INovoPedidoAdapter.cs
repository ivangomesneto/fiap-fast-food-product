namespace FourSix.Controllers.Adapters.Pedidos.NovoPedido
{
    public interface INovoPedidoAdapter
    {
        Task Inserir(NovoPedidoRequest pedido);
    }
}
