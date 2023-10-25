using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorTipo
{
    public class ObtemProdutoPorTipoUseCase : IObtemProdutoPorTipoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private IOutputPort _outputPort;

        public ObtemProdutoPorTipoUseCase(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
            this._outputPort = new ObtemProdutoPorTipoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(string tipo) =>
            this.ObtemProduto(id);

        private async Task ObtemProdutoPorTipo(string tipo)
        {
            var produto = this._produtoRepository
                  .Listar().Where(x => x.id == id).FirstOrDefault();

            if (produto != null)
            {
                this._outputPort.Ok(produto);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}