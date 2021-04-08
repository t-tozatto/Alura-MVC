using Alura_MVC.Models;

namespace Alura_MVC.Repositories.Interfaces
{
    public interface ICadastroRepository
    {
        Cadastro UpdateCadastro(int idCadastro, Cadastro cadastro);
    }
}
