using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryDTO
{
    public class ShoppingCartData
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public Products Product { get; set; }
    }
}
