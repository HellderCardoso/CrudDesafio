using Microsoft.EntityFrameworkCore;
using Stefanini.Domain.Model;

namespace Stefanini.Data.Context
{
    public class StefaniniContext : DbContext
    {
        public StefaniniContext(DbContextOptions<StefaniniContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<__ScriptMigrationHistory> __ScriptMigrationHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18,2)");
            });

        }
    }
}
