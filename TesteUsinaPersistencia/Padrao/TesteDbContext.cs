using Microsoft.EntityFrameworkCore;
using TesteUsinaPersistencia.Model;

namespace TesteUsinaPersistencia.Padrao
{
    public class TesteDbContext : DbContext
    {
        public TesteDbContext(DbContextOptions<TesteDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
