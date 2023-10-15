using FourSix.Domain.Entities;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    internal class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context context) : base(context)
        {
        }
    }
}
