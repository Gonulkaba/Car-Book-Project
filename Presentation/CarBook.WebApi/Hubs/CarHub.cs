﻿using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;

namespace CarBook.WebApi.Hubs
{
	public class CarHub : Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendCarCount()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<GetCarCountQueryResult>(jsonData);
				await Clients.All.SendAsync("ReceiveCarCount", data.CarCount);
			}
		}
	}
}
