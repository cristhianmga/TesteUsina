using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TesteUsinaPersistencia.Interface;

namespace TesteUsinaPersistencia.Padrao
{
    public class PadraoDB : IPadraoDB
    {
        private readonly TesteDbContext _context;

        public PadraoDB(TesteDbContext context)
        {
            _context = context;
        }


        public async Task<E> Salvar<E>(E entity) where E : class
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<E> Atualizar<E>(E entity) where E : class
        {
            _context.Set<E>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<string> Excluir<E>(int id) where E : class
        {
            E? entity = _context.Set<E>().Find(id);
            if (entity == null)
            {
                throw new Exception("Objeto não encontrado");
            }
            else
            {
                _context.Set<E>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return "Objeto Excluido";
            }
        }

        public async Task<E> Obter<E>(int id) where E : class
        {
            return await _context.Set<E>().FindAsync(id);
        }

        public IQueryable<E> ObterTodos<E>() where E : class
        {
            return  _context.Set<E>().AsQueryable();
        }
    }
}
