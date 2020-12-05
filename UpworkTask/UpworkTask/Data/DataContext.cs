using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UpworkTask.Entities;

namespace UpworkTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefDbConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Used to get the product specifications from db. You can add as many as you want there
        /// </summary>
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }

        /// <summary>
        /// Used to get the product languages from db. You can add as many as you want there
        /// </summary>
        public DbSet<ProductLanguage> ProductLanguages { get; set; }
    }
}