using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management.Models
{
    public class OrderDetails
    {
        [Key]
        public int id { get; set; }
        public string CustomerName { get; set; }
        public string Items { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
