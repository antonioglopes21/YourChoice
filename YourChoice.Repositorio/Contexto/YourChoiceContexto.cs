using Microsoft.EntityFrameworkCore;
using YourChoice.Dominio.Entidades;
using YourChoice.Repositorio.Config;

namespace YourChoice.Repositorio.Contexto
{
    public class YourChoiceContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<ProdutoIngrediente> ProdutoIngredientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }


        public YourChoiceContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoIngredienteConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
