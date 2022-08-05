using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryDTO
{
    public class ProductItemData
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
