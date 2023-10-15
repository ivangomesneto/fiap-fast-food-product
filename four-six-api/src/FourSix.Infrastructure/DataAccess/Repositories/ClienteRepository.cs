using FourSix.Domain.Entities;

namespace FourSix.Infrastructure.DataAccess.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Context context) : base(context)
        {
        }
    }
}
