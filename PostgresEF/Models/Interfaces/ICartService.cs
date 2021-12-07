using System.Collections.Generic;

namespace PostgresEF.Models.Interfaces
{
    public interface ICartService
    {
        double Total();
        IEnumerable<ICartItem> Items();
    }
}