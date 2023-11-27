using DataModels.Mappings;
using DataModels.Mappings.AnonyousUsersMapping;
using DataModels.Mappings.FaqMapping;
using DataModels.Mappings.OrderMapping;
using DataModels.Models;
using DataModels.Models.Cart;
using DataModels.Models.Faq;
using DataModels.Models.Order;
using DataModels.Models.Product;
using DataModels.Models.Review;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DAL
{
    public class ApplicationDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<ProductType>(new ProductTypeMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());
            modelBuilder.ApplyConfiguration<Order>(new OrderMap());         
            modelBuilder.ApplyConfiguration<Faq>(new FaqMap());                 
        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }   
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
