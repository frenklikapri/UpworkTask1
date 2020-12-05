using AutoMapper;
using AutoMapper.QueryableExtensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using UpworkTask.Dtos;
using UpworkTask.Entities;
using UpworkTask.Interfaces;

namespace UpworkTask.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly Logger _logger;
        private readonly DataContext _dbContext;
        private readonly MapperConfiguration _mapper;

        public ProductsRepository(DataContext dbContext, MapperConfiguration mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                var product = await _dbContext
                    .Products
                    .FirstAsync(p => p.Id == productId);

                _dbContext.Products.Remove(product);

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            try
            {
                var products = await _dbContext
                    .Products
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        EAN = p.EAN,
                        MaterialNumber = p.MaterialNumber
                    })
                    .ToListAsync();

                return products;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new List<ProductDto>();
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            try
            {
                var product = await _dbContext
                    .Products
                    .FirstAsync(p => p.Id == productId);

                var mapper = new Mapper(_mapper);

                return mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<SaveProductResultDto> SaveProductAsync(ProductDto productDto)
        {
            try
            {
                // check if any other product exists
                if (await _dbContext.Products.AnyAsync(p => (p.EAN == productDto.EAN || p.MaterialNumber == productDto.MaterialNumber) && p.Id != productDto.Id))
                    return new SaveProductResultDto
                    {
                        Success = false,
                        ProductExists = true
                    };

                // if we have an id then we edit the product
                if (productDto.Id > 0)
                {
                    var productInDb = await _dbContext
                        .Products
                        .FirstAsync(p => p.Id == productDto.Id);

                    productInDb.EAN = productDto.EAN;
                    productInDb.MaterialNumber = productDto.MaterialNumber;
                    productInDb.Specifications = productDto.Specifications;

                    var success = await _dbContext.SaveChangesAsync() > 0;

                    return new SaveProductResultDto
                    {
                        Success = success
                    };
                }
                else
                {
                    var mapper = new Mapper(_mapper);
                    var toAdd = mapper.Map<Product>(productDto);
                    _dbContext.Products.Add(toAdd);

                    var success = await _dbContext.SaveChangesAsync() > 0;

                    return new SaveProductResultDto
                    {
                        Success = success
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new SaveProductResultDto();
            }
        }

        /// <summary>
        /// Used to get the languages and specifications from database in order to have dynamic info
        /// </summary>
        /// <returns></returns>
        public async Task<ProductLanguagesAndSpecificationsDto> GetProductLanguagesAndSpecificationsAsync()
        {
            try
            {
                var langs = await _dbContext
                    .ProductLanguages
                    .ToListAsync();

                var specs = await _dbContext
                    .ProductSpecifications
                    .ToListAsync();

                return new ProductLanguagesAndSpecificationsDto
                {
                    Languages = langs,
                    Specifications = specs
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new ProductLanguagesAndSpecificationsDto
                {
                    Languages = new List<ProductLanguage>(),
                    Specifications = new List<ProductSpecification>()
                };
            }
        }
    }
}