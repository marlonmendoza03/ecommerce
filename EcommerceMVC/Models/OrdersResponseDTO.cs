using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.EcommerceDTOs
{
    public class OrdersResponse
    {
        public List<OrdersResponseDTO> Orders { get; set; }
    }
    public class OrdersResponseDTO
    {
        [Key]
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }
        public int OrderQuanity { get; set; }
        public int OrderedBy { get; set; }
        public string OrderDate { get; set; }
    }
}
