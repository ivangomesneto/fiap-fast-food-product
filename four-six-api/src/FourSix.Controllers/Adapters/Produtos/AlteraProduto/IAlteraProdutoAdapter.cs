namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    public interface IAlteraProdutoAdapter
    {
        Task Alterar(Guid id, AlteraProdutoRequest produto);
    }
}
