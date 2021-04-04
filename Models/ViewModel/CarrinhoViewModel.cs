using System.Collections.Generic;
using System.Linq;

namespace Alura_MVC.Models.ViewModel
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> item)
        {
            Item = item;
        }

        public IList<ItemPedido> Item { get; }
        
        public decimal Total => Item.Sum(i => i.PrecoUnitario * i.Quantidade);
    }
}
