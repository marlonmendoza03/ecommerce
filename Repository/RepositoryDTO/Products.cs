using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.RepositoryDTO
{
    public class Products
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string? ProductName { get; set; }

        [Column("product_description")]
        public string? ProductDescription { get; set; }

        [Column("product_price")]
        public float ProductPrice { get; set; }

        [Column("product_quantity")]
        public int ProductQuantity { get; set; }

        [Column("product_image_1")]
        public string? ProductImage1 { get; set; }

        [Column("product_image_2")]
        public string? ProductImage2 { get; set; }

        [Column("product_image_3")]
        public string? ProductImage3 { get; set; }

        [Column("date_added")]
        public DateTime DateAdded { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; } 
    }
}