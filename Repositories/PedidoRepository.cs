using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;

namespace Alura_MVC.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
