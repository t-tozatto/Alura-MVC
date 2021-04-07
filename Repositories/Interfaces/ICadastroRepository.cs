using Alura_MVC.Models;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface ICadastroRepository
    {
        void UpdateCadastro(int idCadastro, Cadastro cadastro);
    }
}
