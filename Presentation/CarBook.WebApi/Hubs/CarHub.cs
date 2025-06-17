using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

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
			var values = await responseMessage.Content.ReadAsStringAsync();
			await Clients.All.SendAsync("ReceiveCarCount",values);
		}
	}
}
