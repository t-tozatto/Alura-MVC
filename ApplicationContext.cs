using Alura_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura_MVC
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Produto
            modelBuilder.Entity<Produto>()
                .HasKey(produto => produto.Id);
            #endregion

            #region Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(pedido => pedido.Id);

            modelBuilder.Entity<Pedido>()
                .HasMany(pedido => pedido.Item)
                .WithOne(item => item.Pedido);

            modelBuilder.Entity<Pedido>()
                .HasOne(pedido => pedido.Cadastro)
                .WithMany(cadastro => cadastro.Pedido)
                .IsRequired();
            #endregion

            #region Cadastro
            modelBuilder.Entity<Cadastro>()
                .HasKey(cadastro => cadastro.Id);

            modelBuilder.Entity<Cadastro>()
                .HasMany(cadastro => cadastro.Pedido);
            #endregion

            #region ItemPedido
            modelBuilder.Entity<ItemPedido>()
                .HasKey(item => item.Id);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(item => item.Pedido)
                .WithMany(pedido => pedido.Item);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(item => item.Produto);
            #endregion

        }
    }
}
