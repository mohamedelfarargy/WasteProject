using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Entity
{
    public class WasteType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? WasteName { get; set; }



        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public ICollection<RecyclingRequest> RecyclingRequests { get; set; } = new HashSet<RecyclingRequest>();

    }
}
