using FourSix.WebApi.ViewModels;

namespace FourSix.WebApi.UseCases.Produtos.ObtemProdutoPorCategoria
{
    public class ObtemProdutoPorCategoriaResponse
    {


        public ObtemProdutoPorCategoriaResponse(IList<ProdutoModel> produtosModel) => this.Produtos = produtosModel;
        public IList<ProdutoModel> Produtos { get; }
    }
}
