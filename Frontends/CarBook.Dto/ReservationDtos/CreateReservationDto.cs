using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReservationDtos
{
	public class CreateReservationDto
	{
        [Required(ErrorMessage = "Ad alanı boş geçilemez.")]
        [MinLength(2, ErrorMessage = "Ad en az 2 karakter olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez.")]
        [MinLength(2, ErrorMessage = "Soyad en az 2 karakter olmalıdır.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş geçilemez.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Alış lokasyonu seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir alış lokasyonu seçiniz.")]
        public int PickUpLocationID { get; set; }

        [Required(ErrorMessage = "Teslim lokasyonu seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir teslim lokasyonu seçiniz.")]
        public int DropOffLocationID { get; set; }

        [Required]
        public int CarID { get; set; }

        [Required(ErrorMessage = "Yaş alanı boş geçilemez.")]
        [Range(21, 100, ErrorMessage = "Araç kiralama için minimum yaş 21 olmalıdır.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Ehliyet yılı boş geçilemez.")]
        [Range(1, 80, ErrorMessage = "Geçerli bir ehliyet yılı giriniz.")]
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
    }
}
