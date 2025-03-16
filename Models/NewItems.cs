using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management.Models
{
    public class NewItems
    {
        [Key]
        public int Id { get; set; }
        public string foodname { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}
