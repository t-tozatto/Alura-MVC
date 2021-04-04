using Alura_MVC.Models.ViewModel;

namespace Alura_MVC.Models.Response
{
    public class AtualizarQuantidadeItemResponse
    {
        public AtualizarQuantidadeItemResponse(ItemPedido item, CarrinhoViewModel carrinho)
        {
            Item = item;
            Carrinho = carrinho;
        }

        public ItemPedido Item { get; }
        public CarrinhoViewModel Carrinho { get; }
    }
}
