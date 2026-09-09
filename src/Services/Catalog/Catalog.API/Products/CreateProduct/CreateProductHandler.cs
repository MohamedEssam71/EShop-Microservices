namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, string Description, string ImageFile, List<string> Category, decimal Price) :
        ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class  CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Product image file is required.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Product category is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Product price must be greater than zero.");
        }
        
    }

    internal class CreateProductCommandHandler(IDocumentSession Session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Category = command.Category,
                Price = command.Price
            };

            // Save the product to the database or any other storage mechanism here
            Session.Store(product);
            await Session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }

    }
}

