namespace FourSix.Controllers.Adapters.Pedidos.CancelaPedido
{
    public interface ICancelaPedidoAdapter
    {
        Task Cancelar(CancelaPedidoRequest pedido);
    }
}
