namespace FourSix.Domain.Entities
{
    public enum CategoriaProduto
    {
        Lanche,
        Acompanhamento,
        Sobremesa
    }

    public class Produto : BaseEntity, IAggregateRoot
    {
        public Produto(string nome, string descricao, CategoriaProduto categoria, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
        }

        public string Nome { get; }
        public string Descricao { get; } 
        public CategoriaProduto Categoria { get; }
        public decimal Preco { get; }
    }
}
