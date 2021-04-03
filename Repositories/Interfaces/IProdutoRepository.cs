using Alura_MVC.Models;
using System.Collections.Generic;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        List<Produto> GetProdutos();
    }
}