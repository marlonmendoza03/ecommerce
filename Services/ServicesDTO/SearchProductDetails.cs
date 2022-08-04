using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class SearchProductDetails
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string? ResultMessage { get; set; }
    }
}
