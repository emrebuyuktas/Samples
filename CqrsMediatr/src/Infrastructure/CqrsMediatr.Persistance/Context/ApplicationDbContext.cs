using CqrsMediatr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CqrsMediatr.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Pen",
                CreateDate = DateTime.Now,
                Quantity = 100,
                Value = 10
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Paper",
                CreateDate = DateTime.Now,
                Quantity = 200,
                Value = 1
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Book",
                CreateDate = DateTime.Now,
                Quantity = 30,
                Value = 30
            }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
