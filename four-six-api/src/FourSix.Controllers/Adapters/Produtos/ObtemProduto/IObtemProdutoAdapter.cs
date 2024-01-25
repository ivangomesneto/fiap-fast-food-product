namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    public interface IObtemProdutoAdapter
    {
        Task Obter(Guid id);
    }
}
