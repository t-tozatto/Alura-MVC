using Alura_MVC.Models;
using Alura_MVC.Models.Response;
using Alura_MVC.Models.ViewModel;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura_MVC.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemPedidoRepository itemPedidoRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(ApplicationContext context, 
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository,
            IProdutoRepository produtoRepository,
            ICadastroRepository cadastroRepository) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.produtoRepository = produtoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public void AddItemPedido(string codigoProduto, Pedido pedido)
        {
            if(!string.IsNullOrWhiteSpace(codigoProduto))
            {
                if (pedido == null)
                    throw new ArgumentException("Pedido não encontrado!");

                Produto produto = produtoRepository.GetProduto(codigoProduto);
                if (produto == null)
                    throw new ArgumentException("Produto não encontrado!");

                ItemPedido itemPedido = itemPedidoRepository.GetItemPedido(produto.Id, pedido.Id); 
                if (itemPedido == null)
                    itemPedidoRepository.AdicionarItemPedido(new ItemPedido(pedido, produto, 1, produto.Preco), false);

                context.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            int? pedidoId = GetPedidoId();
            Pedido pedido;
            
            if (pedidoId > 0)
                pedido = dbSet.Where(pedido => pedido.Id == pedidoId)
                    .Include(p => p.Item)
                        .ThenInclude(i => i.Produto)
                    .SingleOrDefault();
            else
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                context.SaveChanges();
                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("PedidoId");
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("PedidoId", pedidoId);
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            Pedido pedido = GetPedido();
            cadastroRepository.UpdateCadastro(pedido.Cadastro.Id, cadastro);
            return pedido;
        }

        public AtualizarQuantidadeItemResponse UpdateQuantidade(int id, int quantidade)
        {
            ItemPedido item = itemPedidoRepository.GetItemPedido(id);

            if (item == null)
                throw new ArgumentException("Item do pedido não encontrado");

            item.UpdateQuantidade(quantidade);

            if (quantidade < 1)
                itemPedidoRepository.DeleteItem(item, false);

            context.SaveChanges();

            return new AtualizarQuantidadeItemResponse(item, new CarrinhoViewModel(GetPedido().Item));
        }
    }
}
