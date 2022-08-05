using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public float TotalCost { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
