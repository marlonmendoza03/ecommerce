
using System.ComponentModel.DataAnnotations;

namespace Repository.RepositoryDTO
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roletype { get; set; }
        public bool isActive { get; set; }
    }
}
