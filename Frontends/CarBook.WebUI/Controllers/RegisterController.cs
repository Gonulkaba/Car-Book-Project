﻿using CarBook.Dto.BrandDtos;
using CarBook.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult CreateAppUser()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
		{
            if (!ModelState.IsValid)
            {
                return View(createRegisterDto);
            }

            var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createRegisterDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5000/api/Registers", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
