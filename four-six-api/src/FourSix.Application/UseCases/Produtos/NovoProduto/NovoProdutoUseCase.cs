using FourSix.Application.Services;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoUseCase : INovoProdutoUseCase
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
            // ver isso aqui
            this._outputPort = new AlteraProdutoPresenter();
        }

        
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(Produto produto) =>
            this.NovoProduto(produto);

        private async Task NovoProduto(Produto produto)
        {


            await this._produtoRepository
                // é o salvar?
                 .Incluir(produto)
                 .ConfigureAwait(false);

            // q q é isso?
            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(produto);

        }
    }
}
