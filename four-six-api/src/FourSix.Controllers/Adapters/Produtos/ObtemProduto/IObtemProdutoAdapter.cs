namespace FourSix.Controllers.Adapters.Produtos.ObtemProduto
{
    public interface IObtemProdutoAdapter
    {
        Task Get(Guid id);
    }
}
