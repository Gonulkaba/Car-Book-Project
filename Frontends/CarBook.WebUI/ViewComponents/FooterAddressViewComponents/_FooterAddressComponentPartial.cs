﻿using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressViewComponents
{
	public class _FooterAddressComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/FooterAddresses");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
