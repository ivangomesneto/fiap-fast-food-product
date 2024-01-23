namespace FourSix.Controllers.Adapters.Produtos.NovoProduto
{
    public interface INovoProdutoAdapter
    {
        Task Inserir(NovoProdutoRequest produto);
    }
}
