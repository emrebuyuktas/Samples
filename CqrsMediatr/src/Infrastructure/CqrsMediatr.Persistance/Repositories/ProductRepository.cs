using CqrsMediatr.Application.Interfaces.Repositories;
using CqrsMediatr.Domain.Entities;
using CqrsMediatr.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsMediatr.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }
    }
}
