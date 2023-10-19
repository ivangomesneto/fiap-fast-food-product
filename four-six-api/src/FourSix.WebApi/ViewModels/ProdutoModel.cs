using FourSix.Domain.Entities;

namespace FourSix.WebApi.ViewModels
{
    public class ProdutoModel
    {
        public ProdutoModel(Produto produto)
        {
            Id = produto.Id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
        }

        public Guid Id { get; set; }
        public string Descricao { get; }
        public string Nome { get; }
        public string Categoria { get; }
        public string Preco { get; }

    }
}
