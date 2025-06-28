using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReviewDtos
{
	public class CreateReviewDto
	{
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        [MinLength(5, ErrorMessage = "İsim en az 5 karakter olmalıdır.")]
        public string CustomerName { get; set; }

        public string? CustomerImage { get; set; }

        [Required(ErrorMessage = "Yorum alanı boş bırakılamaz.")]
        [MinLength(25, ErrorMessage = "Yorum en az 25 karakter olmalıdır.")]
        public string Comment { get; set; }
        public int RatingValue { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        [Required]
        public int CarID { get; set; }
    }
}
