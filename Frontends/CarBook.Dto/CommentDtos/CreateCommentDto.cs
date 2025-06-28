using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentDtos
{
    public class CreateCommentDto
    {
		[Required(ErrorMessage = "Ad alanı boş geçilemez.")]
		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }

		[Required(ErrorMessage = "Yorum alanı boş geçilemez.")]
		public string Description { get; set; }

        [Required]
        public int BlogId { get; set; }

		[Required(ErrorMessage = "Email boş olamaz.")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi girin.")]
		public string Email { get; set; }
	}
}
