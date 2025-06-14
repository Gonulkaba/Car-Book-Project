using CarBook.Dto.ReviewDtos;

namespace CarBook.WebUI.Models
{
	public class CarReviewStatsViewModel
	{
		public List<ResultReviewByCarIdDto> Reviews { get; set; }
		public List<RatingDistributionDto> RatingStats { get; set; }
	}
}
