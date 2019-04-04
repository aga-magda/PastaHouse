using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastaHouse.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        public DateTime ReservationDateTime { get; set; }

        [DisplayName("Imię")]
        [MinLength(2, ErrorMessage = "Zbyt krótkie imię.")]
        [Required(ErrorMessage = "Podaj imię.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Niepoprawne imię.")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [MinLength(2, ErrorMessage = "Zbyt krótkie nazwisko.")]
        [Required(ErrorMessage ="Podaj nazwisko.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Niepoprawne nazwisko.")]
        public string LastName { get; set; }

        [DisplayName("Mail")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres e-mail.")]
        public string Mail { get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Wymagany numer telefonu.")]
        [RegularExpression(@"^([0-9]{9})|(([0-9]{3}-){2}[0-9]{3})$", ErrorMessage = "Niepoprawny numer telefonu.")]
        public string PhoneNumber { get; set; }

        //Foreign key
        public int TableId { get; set; }

        //Navigation property
        public Table Table { get; set; }
    }
}