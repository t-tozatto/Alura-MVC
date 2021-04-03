using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alura_MVC.Models
{
    public class Produto : BaseModel
    {
        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Preco { get; private set; }

        public Produto()
        {

        }

        public Produto(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
    }
}
