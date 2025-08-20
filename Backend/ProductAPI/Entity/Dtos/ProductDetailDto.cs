using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ProductDetailDto : ProductDto
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
