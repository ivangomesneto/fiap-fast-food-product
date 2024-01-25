using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoUseCase : IAlteraProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlteraProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._unitOfWork = unitOfWork;
        }

        public Task Execute(Guid produtoId, string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            this.AlterarProduto(
                new Produto(produtoId,
                    nome,
                    descricao,
                    categoria,
                    preco,
                    true));

        private async Task AlterarProduto(Produto produto)
        {

            if (this._produtoRepository
                .Listar(q => q.Nome == produto.Nome
                && q.Categoria == produto.Categoria).Any())
            {
                throw new Exception("Produto já existe com esse nome e categoria");
            }

            await this._produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
