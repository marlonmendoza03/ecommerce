using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class UserDTO
    {
        [Key]
        public int user_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roletype { get; set; }
        public bool isActive { get; set; }
    }
}
