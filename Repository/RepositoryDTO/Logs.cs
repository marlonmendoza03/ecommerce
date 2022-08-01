
using System.ComponentModel.DataAnnotations;

namespace Repository.RepositoryDTO
{
    public class Logs
    {
        [Key]
        public int log_id { get; set; }
        public string log_description { get; set; }
        public int added_by { get; set; }
        public DateTime log_date { get; set; }
    }
}
