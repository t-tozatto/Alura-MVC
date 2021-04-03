using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Alura_MVC.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
        [Required]
        [DataMember]
        public Produto Produto { get; private set; }
        [Required]
        [DataMember]
        [JsonProperty]
        public int Quantidade { get; private set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [DataMember]
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

        public ItemPedido(int id, int quantidade)
        {
            Id = id;
            Quantidade = quantidade;
        }

        internal void IncrementarQuantidade()
        {
            Quantidade += 1;
        }

        internal void DiminuirQuantidade()
        {
            if (Quantidade > 0)
                Quantidade += 1;
        }

        internal void UpdateQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}
