using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;

namespace Alura_MVC.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
