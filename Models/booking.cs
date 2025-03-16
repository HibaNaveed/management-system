using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management.Models
{
    public class booking
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Contact { get; set; }
        public DateOnly Reservationdate { get; set; }
        public TimeOnly Reservationtime { get; set; }
        public int Noofpeople { get; set; }
        public string Message { get; set; }



    }
}
