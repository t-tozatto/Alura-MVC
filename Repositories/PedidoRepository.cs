using Alura_MVC.Models;
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

        public PedidoRepository(ApplicationContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddItemPedido(string codigoProduto, Pedido pedido)
        {
            if(!string.IsNullOrWhiteSpace(codigoProduto))
            {
                if (pedido == null)
                    throw new ArgumentException("Pedido não encontrado!");

                Produto produto = context.Set<Produto>().Where(p => p.Codigo.Equals(codigoProduto)).SingleOrDefault();
                if (produto == null)
                    throw new ArgumentException("Produto não encontrado!");

                ItemPedido itemPedido = context.Set<ItemPedido>()
                    .Include(i => i.Produto)
                    .Include(i => i.Pedido)
                    .Where(ip => ip.Produto.Id.Equals(produto.Id) && ip.Pedido.Id.Equals(pedido.Id))
                    .SingleOrDefault();

                if (itemPedido == null)
                {
                    itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                    context.Set<ItemPedido>().Add(itemPedido);
                }
                else
                {
                    itemPedido.IncrementarQuantidade();
                    context.Set<ItemPedido>().Update(itemPedido);
                }

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
    }
}
