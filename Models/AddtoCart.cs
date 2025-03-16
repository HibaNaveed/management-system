using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management.Models
{
    public class AddtoCart
    {
        [Key]
        public int Id { get; set; }

        public string Item { get; set; }
        public int Quantity { get; set; }

    }
}
