using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.InativaProduto
{
    public class InativaProdutoUseCase : IInativaProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InativaProdutoUseCase(
            IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._unitOfWork = unitOfWork;
        }

        public Task Execute(Guid produtoId) => this.ExcluiProduto(produtoId);

        private async Task ExcluiProduto(Guid produtoId)
        {
            var produto = this._produtoRepository
                .Obter(produtoId);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produto.InativarProduto();

            await this._produtoRepository
                 .Alterar(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
