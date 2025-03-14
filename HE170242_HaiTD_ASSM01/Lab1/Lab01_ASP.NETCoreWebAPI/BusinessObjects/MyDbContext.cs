﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Beverages"},
                    new Category { CategoryId = 2, CategoryName = "Condiments"},
                    new Category { CategoryId = 3, CategoryName = "Confections"},
                    new Category { CategoryId = 4, CategoryName = "Dairy Products"},
                    new Category { CategoryId = 5, CategoryName = "Grains/Cereals"},
                    new Category { CategoryId = 6, CategoryName = "Meat/Poyltry"},
                    new Category { CategoryId = 7, CategoryName = "Produce"},
                    new Category { CategoryId = 8, CategoryName = "Seafood"}

            );
        }
    }
}
