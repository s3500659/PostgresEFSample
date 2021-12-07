using System.Collections.Generic;

namespace PostgresEF.Models.Interfaces
{
    public interface IShipmentService
    {
        void Ship(IAddressInfo addressInfo, IEnumerable<CartItem> items);
    }
}