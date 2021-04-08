using Alura_MVC.Models;
using Alura_MVC.Repositories.Interfaces;
using System;
using System.Linq;

namespace Alura_MVC.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }

        public Cadastro UpdateCadastro(int idCadastro, Cadastro cadastro)
        {
            Cadastro cadastroDb = dbSet.Where(c => c.Id.Equals(idCadastro)).SingleOrDefault();

            if (cadastroDb == null)
                throw new ArgumentException("Não foi possível achar o cadastro");

            cadastroDb.Update(cadastro);
            context.SaveChanges();

            return cadastroDb;
        }
    }
}
