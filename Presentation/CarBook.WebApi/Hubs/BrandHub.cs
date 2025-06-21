using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;

namespace CarBook.WebApi.Hubs
{
    public class BrandHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendBrandCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/Statistics/GetBrandCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GetBrandCountQueryResult>(jsonData);
                await Clients.All.SendAsync("ReceiveBrandCount", data.BrandCount);
            }
        }
    }
}
