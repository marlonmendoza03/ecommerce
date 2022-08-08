using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryDTO
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public ShoppingCartData Cart { get; set; }
    }

    public class ShoppingCartData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
