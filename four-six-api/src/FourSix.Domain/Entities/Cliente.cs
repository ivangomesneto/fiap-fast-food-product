namespace FourSix.Domain.Entities
{
    public class Cliente : IAggregateRoot
    {
        public Cliente(string cpf, string nome, string email)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Email = email;
        }
        public string Cpf { get; }
        public string Nome { get; }
        public string Email { get; }
    }
}
