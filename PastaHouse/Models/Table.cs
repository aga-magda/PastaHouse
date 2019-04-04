using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PastaHouse.Models
{
    public class Table
    {
        public int TableId { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        //Foreign table collection
        public ICollection<Reservation> Reservation { get; set; }
    }
}