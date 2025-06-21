using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;

namespace CarBook.WebApi.Hubs
{
	public class LocationHub : Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LocationHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendLocationCount()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5000/api/Statistics/GetLocationCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<GetLocationCountQueryResult>(jsonData);
				await Clients.All.SendAsync("ReceiveLocationCount", data.LocationCount);
			}
		}
	}
}
