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
    }
}