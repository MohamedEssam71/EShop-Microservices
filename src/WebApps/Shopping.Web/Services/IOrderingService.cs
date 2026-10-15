
namespace Shopping.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
        Task<GetOrderResponse> GetOrders(int? pageIndex = 1, int? pageSize = 10);

        [Get("/ordering-service/orders/customer/{customerId}")]
        Task<GetOrdersByCustomerResponse> GetOrderByCustomer(Guid customerId);

        [Get("/ordering-service/orders/{orderName}")]
        Task<GetOrdersByNameResponse> GetOrderByName(string orderName);
    }
}
