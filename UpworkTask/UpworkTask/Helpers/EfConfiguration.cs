using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UpworkTask.Data;

namespace UpworkTask.Helpers
{
    public class EfConfiguration
    {
        public static void Configure()
        {
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }
    }
}