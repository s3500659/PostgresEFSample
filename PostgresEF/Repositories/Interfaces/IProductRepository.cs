using PostgresEF.Interfaces;
using PostgresEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEF.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<IProduct>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update(Product product);
    }
}
