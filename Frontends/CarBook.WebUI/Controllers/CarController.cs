using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCars(int page = 1, int pageSize = 6)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/CarPricings");

            if (!responseMessage.IsSuccessStatusCode)
                return Json(new { success = false });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var allCars = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);

            var pagedCars = allCars.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalItems = allCars.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            return Json(new
            {
                success = true,
                data = pagedCars,
                totalPages = totalPages,
                currentPage = page
            });
        }
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";

            ViewBag.carid = id;

            return View();
        }
		[HttpGet]
		public PartialViewResult AddReview()
		{
			return PartialView();
		}
		[HttpPost]
		public async Task<IActionResult> AddReview(CreateReviewDto createReviewDto)
		{
			if (!ModelState.IsValid)
			{
				TempData["ReviewError"] = "Lütfen eksik veya hatalı alanları düzeltin.";
				return RedirectToAction("CarDetail", new { id = createReviewDto.CarID });
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createReviewDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5000/api/Reviews", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				TempData["ReviewSuccess"] = "Yorumunuz başarıyla kaydedildi.";
			}
			else
			{
				TempData["ReviewError"] = "Sunucu hatası oluştu. Lütfen tekrar deneyin.";
			}
            return RedirectToAction("CarDetail", new { id = createReviewDto.CarID });
        }
	}
}
