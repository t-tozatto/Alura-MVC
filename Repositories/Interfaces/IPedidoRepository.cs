using Alura_MVC.Models;
using Alura_MVC.Models.Response;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItemPedido(string codigoProduto, Pedido pedido);
        AtualizarQuantidadeItemResponse UpdateQuantidade(int id, int quantidade);
        Pedido UpdateCadastro(Cadastro cadastro);
    }
}
