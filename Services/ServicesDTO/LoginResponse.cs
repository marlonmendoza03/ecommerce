using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class LoginResponse
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string roletype { get; set; }
        public bool isActive { get; set; }
        public string? ResultMessage { get; set; }
    }
}



