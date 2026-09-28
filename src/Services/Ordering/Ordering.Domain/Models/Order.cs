using Ordering.Domain.Abstractions;
using System.Net.Sockets;

namespace Ordering.Domain.Models
{
    public class Order : Aggregate<Guid>
    {
        private readonly List<OrderItems> _orderItems = new();
        public IReadOnlyList<OrderItems> OrderItems => _orderItems.AsReadOnly();

        public Guid CustomerId { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public decimal TotalPrice
        {
            get => OrderItems.Sum(x => x.Price * x.Quantity);
            private set { }
        }

    }
}
