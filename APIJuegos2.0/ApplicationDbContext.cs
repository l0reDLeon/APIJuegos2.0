using APIJuegos2._0.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIJuegos2._0
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Juegos> Juegos { get; set; }
        //public DbSet<Plataforma> Plataforma { get; set; }
    }
}
