namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);
        Task<GetProductByCategoryResponse> GetProductByCategory(Guid categoryId);
        Task<GetProductByIdResponse> GetProductById(Guid productId);
    }
}
