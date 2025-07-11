﻿using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
	[Route("Admin/AdminBlog")]
	public class AdminBlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminBlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/Blogs/GetAllBlogsWithAuthorList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("RemoveBlog/{id}")]
		public async Task<IActionResult> RemoveBlog(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5000/api/Blogs/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
			}
			return View();
		}
	}
}
