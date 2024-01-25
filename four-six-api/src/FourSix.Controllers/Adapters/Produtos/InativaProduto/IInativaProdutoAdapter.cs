namespace FourSix.Controllers.Adapters.Produtos.InativaProduto
{
    public interface IInativaProdutoAdapter
    {
        Task Inativar(Guid id);
    }
}
