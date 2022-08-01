using System.ComponentModel.DataAnnotations;

namespace Repository.RepositoryDTO
{
    public class Products
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public double product_price { get; set; }
        public int product_quantity { get; set; }
        public string product_image_1 { get; set; }
        public string product_image_2 { get; set; }
        public string product_image_3 { get; set; }
        public DateTime date_added { get; set; }
    }
}
