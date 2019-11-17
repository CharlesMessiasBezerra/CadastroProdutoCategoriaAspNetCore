using Microsoft.EntityFrameworkCore;
using App.Domain.AppContext;

namespace App.Infrastructure.Model
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaDB> CategoriaDB { get; set; }
        public virtual DbSet<ProdutoDB> ProdutoDB { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

