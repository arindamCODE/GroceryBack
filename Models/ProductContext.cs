using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }

        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
    }
}