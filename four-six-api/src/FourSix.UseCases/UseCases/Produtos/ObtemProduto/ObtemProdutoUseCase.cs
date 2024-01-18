using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.ObtemProduto
{
    public class ObtemProdutoUseCase : IObtemProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObtemProdutoUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public Task<Produto> Execute(Guid id) => this.ObtemProduto(id);

        private async Task<Produto> ObtemProduto(Guid id)
        {
            var produto = this._produtoRepository
                  .Listar().Where(x => x.Id == id).FirstOrDefault();

            if (produto != null)
            {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }
    }
}