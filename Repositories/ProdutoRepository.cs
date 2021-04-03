using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Alura_MVC.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }

        public List<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (Livro livro in livros)
            {
                if (!dbSet.Where(produto => produto.Codigo.Equals(livro.Codigo)).Any())
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }
            
            context.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
