using Alura_MVC.Models;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int id);
        ItemPedido GetItemPedido(int idProduto, int idPedido);
        void AdicionarItemPedido(ItemPedido itemPedido, bool salvarAlteracao = true);
        void DeleteItem(int id, bool salvarAlteracao = true);
        void DeleteItem(ItemPedido itemPedido, bool salvarAlteracao = true);
    }
}
