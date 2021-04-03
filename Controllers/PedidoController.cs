using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alura_MVC.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
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
    }
}
