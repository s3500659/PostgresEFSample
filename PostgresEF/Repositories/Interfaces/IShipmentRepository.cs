using System.Collections.Generic;

namespace PostgresEF.Models.Interfaces
{
    public interface IShipmentRepository
    {
        void Ship(IAddressInfo addressInfo, IEnumerable<ICartItem> items);
    }
}