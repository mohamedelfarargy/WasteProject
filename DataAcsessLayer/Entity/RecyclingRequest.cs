using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Entity
{
    public class RecyclingRequest
    {
        public int Id { get; set; }

        public int WasteTypeId { get; set; }
        public WasteType? WasteType { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }





        public string? UserPhone { get; set; }


        public decimal Quantity { get; set; }

        public string? Location { get; set; }
        public string? WasteName { get; set; }
        public decimal TotalPrice { get; set; }


        public DateTime RequestDate { get; set; }


        public string? Status { get; set; }
    }
}
