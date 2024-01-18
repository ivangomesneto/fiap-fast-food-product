using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutoPorCategoriaUseCase : IObtemProdutoPorCategoriaUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObtemProdutoPorCategoriaUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public Task<ICollection<Produto>> Execute(EnumCategoriaProduto categoria) => this.ObtemProdutoPorCategoria(categoria);

        private async Task<ICollection<Produto>> ObtemProdutoPorCategoria(EnumCategoriaProduto categoria)
        {
            var produtos = this._produtoRepository
                  .Listar().Where(x => x.Categoria == categoria
                  && x.Ativo).ToList();

            return produtos;
        }
    }
}