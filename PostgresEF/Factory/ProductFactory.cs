using PostgresEF.Factory.Interfaces;
using PostgresEF.Models;

namespace PostgresEF.Factory
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct()
        {
            return new Product();
        }
    }
}
