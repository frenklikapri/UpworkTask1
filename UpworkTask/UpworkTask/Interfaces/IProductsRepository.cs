using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UpworkTask.Dtos;

namespace UpworkTask.Interfaces
{
    public interface IProductsRepository
    {
        Task<ProductLanguagesAndSpecificationsDto> GetProductLanguagesAndSpecificationsAsync();
        Task<List<ProductDto>> GetProductsAsync();
        Task<SaveProductResultDto> SaveProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int productId);
        Task<ProductDto> GetProductById(int productId);
    }
}