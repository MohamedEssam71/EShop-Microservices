namespace Catalog.API.Products.GetProductById
{
    public record GetProductbyIdQuery(Guid Id) : IRequest<GetProductByIdResult>;
    public record GetProductByIdResult(Product product);
    internal class GetProductByIdQueryHandler(IDocumentSession session)
        : IRequestHandler<GetProductbyIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductbyIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if(product == null)
            {
                throw new ProductNotFoundException(query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
