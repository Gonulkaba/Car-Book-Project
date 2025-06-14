using CarBook.Dto.ReviewDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentsByCarIdComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5000/api/Reviews?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var reviewList = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);

				// ⭐️ Rating'e göre gruplama
				var ratingStats = reviewList
					.GroupBy(r => r.RatingValue)
					.Select(g => new RatingDistributionDto
					{
						RatingValue = g.Key,
						Count = g.Count()
					})
					.ToList();

				// ⭐️ ViewModel'i doldur
				var viewModel = new CarReviewStatsViewModel
				{
					Reviews = reviewList,
					RatingStats = ratingStats
				};

				return View(viewModel);
			}
			return View(new CarReviewStatsViewModel());
		}
	}
}
