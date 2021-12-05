using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEF.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
