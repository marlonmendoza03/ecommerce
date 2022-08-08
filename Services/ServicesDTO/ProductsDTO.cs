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

        public float ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string? DateAdded { get; set; }

        public string? ProductImage1 { get; set; }

        public string? ProductImage2 { get; set; }
        public string? ProductImage3 { get; set; }

        public bool IsActive { get; set; }
        public bool? IsFeatured { get; set; }
    }
}
