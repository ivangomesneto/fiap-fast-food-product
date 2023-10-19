namespace FourSix.Domain.Entities
{
    public enum EnumCategoriaProduto
    {
        Lanche,
        Acompanhamento,
        Sobremesa
    }

    public class Produto : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Produto(){}
        public Produto(Guid id, string nome, string descricao, int categoria, decimal preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
        }

        public string Nome { get; }
        public string Descricao { get; } 
        public int Categoria { get; }
        public decimal Preco { get; }
    }
}
