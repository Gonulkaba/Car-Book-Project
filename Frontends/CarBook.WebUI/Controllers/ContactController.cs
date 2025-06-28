using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
            ViewBag.v1 = "İLETİŞİM";
			ViewBag.v2 = "Bize Ulaşın";
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContactDto)
		{
            if (!ModelState.IsValid)
            {
                TempData["ContactError"] = "Lütfen eksik veya hatalı alanları düzeltin.";
                return View(createContactDto);
            }
            var client = _httpClientFactory.CreateClient();
			createContactDto.SendDate=DateTime.Now;
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5000/api/Contacts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
                TempData["ContactSuccess"] = "Mesajınız başarıyla iletildi.";
            }
            else
            {
                TempData["ContactError"] = "Sunucu hatası oluştu. Lütfen tekrar deneyin.";
            }
            return RedirectToAction("Index");
        }
	}
}
