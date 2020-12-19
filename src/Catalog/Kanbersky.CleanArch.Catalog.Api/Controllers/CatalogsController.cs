using Kanbersky.CleanArch.Catalog.Services.Abstract;
using Kanbersky.CleanArch.Catalog.Services.DTO.Request;
using Kanbersky.CleanArch.Catalog.Services.DTO.Response;
using Kanbersky.CleanArch.Core.Results.ApiResponses.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbersky.CleanArch.Catalog.Api.Controllers
{
    [Route("api/v1/catalogs")]
    [ApiController]
    public class CatalogsController : CleanArchControllerBase
    {
        private readonly IProductService _productService;

        public CatalogsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetAllProduct();
            return ApiOk(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponseModel) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var response = await _productService.GetProductById(id);
            return ApiOk(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            await _productService.DeleteProductById(id);
            return ApiNoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromRoute] string id , [FromBody] UpdateProductRequestModel updateProductRequest)
        {
            var response = await _productService.UpdateProduct(id, updateProductRequest);
            return ApiUpdated(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestModel createProductRequest)
        {
            var response = await _productService.CreateProduct(createProductRequest);
            return ApiCreated(response);
        }
    }
}
