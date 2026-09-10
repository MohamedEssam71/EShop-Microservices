namespace Basket.API.Basket.DeleteBasket
{
    //public record DeleteBasketRequest(string UserName);
    public record DelteBasketReponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));
                
                var response = result.Adapt<DeleteBasketReponse>();
                
                return Results.Ok(response);
            })
            .WithName("DeleteBasket")
            .Produces<DeleteBasketReponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Deletes a shopping cart for a user.")
            .WithDescription("This endpoint deletes a shopping cart for a user." +
            " It accepts a userName and returns a DeleteBasketReponse indicating if the operation was successful.");
        }
    }
}
