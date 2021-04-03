using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using System;
using System.Linq;

namespace Alura_MVC.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

        public void UpdateQuantidade(int id, int quantidade)
        {
            ItemPedido item = dbSet.Where(x => x.Id.Equals(id)).SingleOrDefault();

            if (item == null)
                throw new ArgumentException("Item do pedido não encontrado");

            item.UpdateQuantidade(quantidade);

            context.SaveChanges();
        }
    }
}
