using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.DTO
{
    public class LastActivityDTO
    {
        public decimal Quantity { get; set; }
        public string? WasteName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
