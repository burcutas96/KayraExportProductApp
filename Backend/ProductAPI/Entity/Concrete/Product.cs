using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        
        public DateTime? DeleteDate { get; set; }
    }
}
