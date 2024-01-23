using FourSix.WebApi.ViewModels;

namespace FourSix.Controllers.Adapters.Produtos.ObtemProdutos
{
    public class ObtemProdutosResponse
    {
        public ObtemProdutosResponse(IList<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public IList<ProdutoModel> Produtos { get; }
    }
}
