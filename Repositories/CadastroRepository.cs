using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;

namespace Alura_MVC.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }

        public void UpdateCadastro(int idCadastro, Cadastro cadastro)
        {
            throw new System.NotImplementedException();
        }
    }
}
