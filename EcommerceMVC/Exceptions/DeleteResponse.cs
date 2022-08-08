using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Exceptions
{
    public class DeleteResponse
    {
        [Key]
        public int ProductId { get; set; }

        public string? Result { get; set; } = "Successfully Deleted";
    }
}