using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpworkTask.Dtos;
using UpworkTask.Entities;

namespace UpworkTask.Helpers
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
            });

            return config;
        }
    }
}