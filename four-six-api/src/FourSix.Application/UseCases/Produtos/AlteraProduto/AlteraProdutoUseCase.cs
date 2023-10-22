using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.AlteraProduto
{
    public class AlteraProdutoUseCase : IAlteraProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public AlteraProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new AlteraProdutoPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            this.AlteraProduto(
                new Produto(Guid.NewGuid(),
                    nome,
                    descricao,
                    categoria,
                    preco));

        private async Task AlteraProduto(Produto produto)
        {
            
            if (this._produtoRepository
                .Listar()
                .Any(q => q.Descricao == produto.Descricao
                && q.Categoria==produto.Categoria))
            {
                this._outputPort.Exist();
                return;
            }

            await this._produtoRepository
                 .Incluir(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(produto);
            
        }
    }
}
