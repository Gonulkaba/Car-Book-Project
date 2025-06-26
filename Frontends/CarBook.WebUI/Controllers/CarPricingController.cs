using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
			return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPaginatedPricings(int page = 1, int pageSize = 5)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/CarPricings/GetCarPricingWithTimePeriodList");

            if (!responseMessage.IsSuccessStatusCode)
                return Json(new { success = false });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var allCars = JsonConvert.DeserializeObject<List<ResultCarPricingListWithTimePeriodDto>>(jsonData);

            var pagedCars = allCars.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling((double)allCars.Count / pageSize);

            // timePeriods'ü de dinamik olarak döndürme
            var timePeriods = allCars
                .Where(x => x?.pricingDetails != null)
                .SelectMany(x => x.pricingDetails)
                .Where(p => !string.IsNullOrEmpty(p?.TimePeriodName))
                .Select(p => p.TimePeriodName)
                .Distinct()
                .ToList();

            return Json(new
            {
                success = true,
                data = pagedCars,
                totalPages,
                currentPage = page,
                timePeriods = timePeriods
            });
        }
    }
}
