using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.DTO
{
    public class GetRequestDto
    {

        public string? UserPhone { get; set; }


        public decimal Quantity { get; set; }

        public string? Location { get; set; }
        public string? WasteName { get; set; }
        public decimal TotalPrice { get; set; }


        public DateTime RequestDate { get; set; }
    }
}
