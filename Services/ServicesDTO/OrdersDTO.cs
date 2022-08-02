using System.ComponentModel.DataAnnotations;

namespace Services.ServicesDTO
{
    public class OrdersDTO
    {
        [Key]
        public int order_id { get; set; }
        public double order_amount { get; set; }
        public int order_quantity { get; set; }
        public int ordered_by { get; set; }
        public string order_date { get; set; }
    }
}
