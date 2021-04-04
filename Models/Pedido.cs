using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura_MVC.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        public List<ItemPedido> Item { get; private set; } = new List<ItemPedido>();

        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
