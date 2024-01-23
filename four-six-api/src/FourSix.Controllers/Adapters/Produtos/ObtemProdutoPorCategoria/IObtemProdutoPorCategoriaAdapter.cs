using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutoPorCategoria
{
    public interface IObtemProdutoPorCategoriaAdapter
    {
        Task Get(EnumCategoriaProduto categoria);
    }
}
