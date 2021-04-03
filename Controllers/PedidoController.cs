using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Alura_MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Carrinho(string codigo)
        {
            Pedido pedido = pedidoRepository.GetPedido();
            pedidoRepository.AddItemPedido(codigo, pedido);
            return View(pedido.Item);
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Resumo()
        {
            return View(pedidoRepository.GetPedido());
        }

        [HttpPut] 
        public void AtualizarQuantidadeItem([FromBody] object itemPedido)
        {
            ItemPedido item = JsonConvert.DeserializeObject<ItemPedido>(itemPedido.ToString());
            itemPedidoRepository.UpdateQuantidade(item.Id, item.Quantidade);
        }
    }
}
