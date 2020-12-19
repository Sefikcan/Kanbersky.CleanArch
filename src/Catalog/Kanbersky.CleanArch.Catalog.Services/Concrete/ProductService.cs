using AutoMapper;
using Kanbersky.CleanArch.Catalog.Infrastracture.Entities;
using Kanbersky.CleanArch.Catalog.Services.Abstract;
using Kanbersky.CleanArch.Catalog.Services.DTO.Request;
using Kanbersky.CleanArch.Catalog.Services.DTO.Response;
using Kanbersky.CleanArch.Core.Repositories.Abstract.MongoDB;
using Kanbersky.CleanArch.Core.Results.Exceptions.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMongoGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseModel> CreateProduct(CreateProductRequestModel createProductRequest)
        {
            var mappedProduct = _mapper.Map<Product>(createProductRequest);
            await _productRepository.InsertAsync(mappedProduct);
            return _mapper.Map<ProductResponseModel>(mappedProduct);
        }

        public async Task DeleteProductById(string id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProduct()
        {
            var products = await _productRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByCategory(string category)
        {
            var product = await _productRepository.FindAllAsync(x=>x.Category == category);
            if (product == null)
            {
                throw BaseException.NotFoundException("Product Not Found!");
            }

            return _mapper.Map<IEnumerable<ProductResponseModel>>(product);
        }

        public async Task<ProductResponseModel> GetProductById(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw BaseException.NotFoundException("Product Not Found!");
            }

            return _mapper.Map<ProductResponseModel>(product);
        }

        public async Task<ProductResponseModel> UpdateProduct(string id, UpdateProductRequestModel updateProductRequest)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw BaseException.NotFoundException("Product Not Found!");
            }

            var mappedProduct = _mapper.Map<Product>(updateProductRequest);
            mappedProduct.Id = product.Id;

            var updateProduct = await _productRepository.UpdateAsync(mappedProduct);
            return updateProduct ? _mapper.Map<ProductResponseModel>(mappedProduct) : throw BaseException.BadRequestException("Product Update Fail!");
        }
    }
}
