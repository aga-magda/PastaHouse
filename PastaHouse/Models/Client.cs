using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PastaHouse.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [DisplayName("Imię")]
        [MinLength(2, ErrorMessage = "Zbyt krótkie imię.")]
        [Required(ErrorMessage = "Podaj imię.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Niepoprawne imię.")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [MinLength(2, ErrorMessage = "Zbyt krótkie nazwisko.")]
        [Required(ErrorMessage = "Podaj nazwisko.")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Niepoprawne nazwisko.")]
        public string Surname { get; set; }

        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Podaj miasto.")]
        public string City { get; set; }

        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Podaj ulicę.")]
        public string Street { get; set; }

        [DisplayName("Numer domu")]
        [Required(ErrorMessage = "Podaj numer domu.")]
        public string HomeNumber{ get; set; }

        [DisplayName("Numer mieszkania")]
        public int LocalNumber{ get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Wymagany numer telefonu.")]
        [RegularExpression(@"^([0-9]{9})|(([0-9]{3}-){2}[0-9]{3})$", ErrorMessage = "Niepoprawny numer telefonu.")]
        public string Telephone { get; set; }
    }
}