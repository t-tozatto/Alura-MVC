using Alura_MVC.Repositories;
using Alura_MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Alura_MVC
{
    public class DataSource : IDataSource
    {
        private readonly ApplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataSource(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaBD()
        {
            context.Database.Migrate();

            //Salvando os produtos no BD
            produtoRepository.SaveProdutos(GetLivros());
        }

        public List<Livro> GetLivros()
        {
            return JsonConvert.DeserializeObject<List<Livro>>(File.ReadAllText("livros.json"));
        }
    }
}
