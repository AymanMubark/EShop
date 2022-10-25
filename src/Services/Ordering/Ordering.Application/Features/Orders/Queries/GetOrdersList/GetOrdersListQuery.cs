using MediatR;
using Ordering.Application.DTOs;


namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrderResponseDTO>>
    {
        public string userName { get; set; }

        public GetOrdersListQuery(string? userName)
        {
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
