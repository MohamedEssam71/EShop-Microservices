namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketReponse>;
    public record DeleteBasketReponse(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketReponse>
    {
        public async Task<DeleteBasketReponse> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            //TODO: delete cart from db & cache 
            return new DeleteBasketReponse(true);
        }
    }
}
