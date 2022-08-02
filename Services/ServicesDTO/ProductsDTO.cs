using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class ProductsDTO
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
