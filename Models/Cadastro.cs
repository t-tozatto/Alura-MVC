using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura_MVC.Models
{
    public class Cadastro : BaseModel
    {
        public virtual List<Pedido> Pedido { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 5 caracteres")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "E-mail obrigatório")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Complemento obrigatório")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro obrigatório")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Município obrigatório")]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "UF obrigatório")]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "CEP obrigatório")]
        public string CEP { get; set; } = "";

        public Cadastro()
        {
        }

        internal void Update(Cadastro cadastro)
        {
            Funcao.CopyPropertiesTo(this, cadastro);
        }

    }
}
