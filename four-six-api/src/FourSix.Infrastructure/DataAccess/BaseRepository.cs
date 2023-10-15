using FourSix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FourSix.Infrastructure.DataAccess
{
    public class BaseRepository<T> where T : class, IBaseEntity
    {
        internal readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task<T> Obter(Guid id)
        {
            return await _context.Set<T>().FirstAsync(f => f.Id == id);
        }

        public Task<IQueryable<T>> Listar()
        {
            return Task.FromResult(_context.Set<T>().AsQueryable());
        }

        public async Task Incluir(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
        }

        public async Task Alterar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public async Task Excluir(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public Task<int> Salvar()
        {
            return _context.SaveChangesAsync();
        }
    }
}
