using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura_MVC.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

        public void AdicionarItemPedido(ItemPedido itemPedido, bool salvarAlteracao = true)
        {
            dbSet.Add(itemPedido);

            if (salvarAlteracao)
                context.SaveChanges();
        }

        public void DeleteItem(int id, bool salvarAlteracao = true)
        {
            DeleteItem(GetItemPedido(id), salvarAlteracao);
        }

        public void DeleteItem(ItemPedido itemPedido, bool salvarAlteracao = true)
        {
            dbSet.Remove(itemPedido);

            if (salvarAlteracao)
                context.SaveChanges();
        }

        public ItemPedido GetItemPedido(int id)
        {
            return dbSet.Where(x => x.Id.Equals(id)).SingleOrDefault();
        }

        public ItemPedido GetItemPedido(int idProduto, int idPedido)
        {
            return dbSet
                .Include(i => i.Produto)
                .Include(i => i.Pedido)
                .Where(ip => ip.Produto.Id.Equals(idProduto) && ip.Pedido.Id.Equals(idPedido))
                .SingleOrDefault();
        }
    }
}
