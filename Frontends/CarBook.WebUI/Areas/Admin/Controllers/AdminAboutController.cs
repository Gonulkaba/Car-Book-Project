﻿using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
	[Route("Admin/AdminAbout")]
	public class AdminAboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminAboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateAbout")]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateAbout")]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5000/api/Abouts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
			}
			return View();
		}

		[Route("RemoveAbout/{id}")]
		public async Task<IActionResult> RemoveAbout(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5000/api/Abouts/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5000/api/Abouts/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAboutDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5000/api/Abouts/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
			}
			return View();
		}
	}
}
