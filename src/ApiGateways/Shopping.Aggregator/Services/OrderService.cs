using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<OrderModel>> GetOrdersByUserName(string userName)
        {
            return await _client.GetFromJsonAsync<IEnumerable<OrderModel>>(_client.BaseAddress + $"api/v1/Orders/{userName}");
        }
    }
}
