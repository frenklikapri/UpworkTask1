using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UpworkTask.Dtos;
using UpworkTask.Interfaces;

namespace UpworkTask.Controllers.API
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/products/get-specs-langs")]
        public async Task<IHttpActionResult> GetProductsLanguagesAndSpecifications()
        {
            var result = await _productsRepository.GetProductLanguagesAndSpecificationsAsync();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProducts()
        {
            var products = await _productsRepository.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductSpecifications(int id)
        {
            var specifications = await _productsRepository.GetProductById(id);

            return Ok(specifications);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveProduct(ProductDto productDto)
        {
            var result = await _productsRepository.SaveProductAsync(productDto);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            var deleted = await _productsRepository.DeleteProductAsync(id);

            return Ok(new
            {
                Success = deleted
            });
        }
    }
}