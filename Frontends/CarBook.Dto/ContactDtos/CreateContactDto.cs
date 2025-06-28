using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ContactDtos
{
	public class CreateContactDto
	{
        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email adresi boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu alanı boş geçilemez.")]
        [MinLength(5, ErrorMessage = "Lütfen en az 5 karakter konu giriniz!")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş geçilemez.")]
        [MinLength(15, ErrorMessage = "Lütfen en az 15 karakter mesaj giriniz!")]
        public string Message { get; set; }

        public DateTime SendDate { get; set; }

    }
}
