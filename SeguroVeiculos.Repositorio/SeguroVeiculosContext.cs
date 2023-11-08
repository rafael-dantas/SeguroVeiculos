using Microsoft.EntityFrameworkCore;
using SeguroVeiculos.Dominio.Entidades;

namespace SeguroVeiculos.Repositorio
{
    public class SeguroVeiculosContext : DbContext
    {
        public SeguroVeiculosContext(DbContextOptions<SeguroVeiculosContext> option)
            : base(option) { }

        public DbSet<Seguro> Seguros { get; set; }
    }
}