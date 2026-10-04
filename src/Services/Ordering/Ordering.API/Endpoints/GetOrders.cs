using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints
{
    //public record GetOrdersRequest(PaginationRequest PaginationRequest);
    public record GetOrderResponse(PaginationResult<OrderDto> Orders);
    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(request));
                var response = result.Adapt<GetOrderResponse>();
                return Results.Ok(response);
            })
                .WithName("GetOrders")
                .Produces<GetOrderResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get orders")
                .WithDescription("Get orders");
        }
    }
}
