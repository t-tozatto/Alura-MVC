using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alura_MVC.Models
{
    public class ItemPedido : BaseModel
    {
        [Required]
        public Pedido Pedido { get; private set; }
        [Required]
        public Produto Produto { get; private set; }
        [Required]
        public int Quantidade { get; private set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public void IncrementarQuantidade()
        {
            Quantidade += 1;
        }
    }
}
