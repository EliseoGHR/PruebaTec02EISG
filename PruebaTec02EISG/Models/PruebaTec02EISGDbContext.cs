using Microsoft.EntityFrameworkCore;

namespace PruebaTec02EISG.Models
{
    public class PruebaTec02EISGDbContext:DbContext
    {
        public PruebaTec02EISGDbContext(DbContextOptions<PruebaTec02EISGDbContext> options) : base(options)
        {
        }

        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Profesor> Profesores { get; set; }


    }
}
