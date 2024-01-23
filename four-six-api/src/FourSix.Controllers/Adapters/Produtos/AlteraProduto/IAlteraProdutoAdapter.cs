namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    public interface IAlteraProdutoAdapter
    {
        Task Edit(Guid id, AlteraProdutoRequest produto);
    }
}
