

using System.ComponentModel.DataAnnotations;

namespace Repository.RepositoryDTO
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }
        public double order_amount { get; set; }
        public int order_quantity { get; set; }
        public int ordered_by { get; set; }
        public DateTime order_date { get; set; }
    }
}
