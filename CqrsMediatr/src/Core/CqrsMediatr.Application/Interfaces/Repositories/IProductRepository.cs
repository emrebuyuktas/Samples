using CqrsMediatr.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Interfaces.Repositories
{
    public interface IProductRepository:IGenericRepositoryAsync<Product>
    {

    }
}
