using Kanbersky.CleanArch.Catalog.Services.DTO.Request;
using Kanbersky.CleanArch.Catalog.Services.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetAllProduct();

        Task<ProductResponseModel> GetProductById(string id);

        Task<IEnumerable<ProductResponseModel>> GetProductByCategory(string category);

        Task<ProductResponseModel> CreateProduct(CreateProductRequestModel createProductRequest);

        Task<ProductResponseModel> UpdateProduct(string id, UpdateProductRequestModel updateProductRequest);

        Task DeleteProductById(string id);
    }
}
