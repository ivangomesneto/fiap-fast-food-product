using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public interface IObtemProdutoPorCategoriaUseCase
    {
        Task<ICollection<Produto>> Execute(EnumCategoriaProduto categoria);
    }
}
