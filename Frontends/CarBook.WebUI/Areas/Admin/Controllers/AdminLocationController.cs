﻿using CarBook.Dto.LocationDtos;
using CarBook.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	[Route("Admin/AdminLocation")]
	public class AdminLocationController : BaseController
    {
        public AdminLocationController(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        [AllowAnonymous]
        [Route("Index")]
		public async Task<IActionResult> Index()
		{
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5000/api/Locations");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                    return View(values);
                }
            return View();
        }

		[HttpGet]
		[Route("CreateLocation")]
		public IActionResult CreateLocation()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateLocation")]
		public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
		{
            var client = CreateAuthorizedClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5000/api/Locations", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
			}
			return View();
		}

		[Route("RemoveLocation/{id}")]
		public async Task<IActionResult> RemoveLocation(int id)
		{
            var client = CreateAuthorizedClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5000/api/Locations/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateLocation/{id}")]
		public async Task<IActionResult> UpdateLocation(int id)
		{
            var client = CreateAuthorizedClient();
            var responseMessage = await client.GetAsync($"http://localhost:5000/api/Locations/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateLocation/{id}")]
		public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateLocationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5000/api/Locations/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
			}
			return View();
		}
	}
}
