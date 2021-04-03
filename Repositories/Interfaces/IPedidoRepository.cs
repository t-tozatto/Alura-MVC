using Alura_MVC.Models;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItemPedido(string codigoProduto, Pedido pedido);
    }
}
