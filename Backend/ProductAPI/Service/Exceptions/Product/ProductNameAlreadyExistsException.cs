using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions.Product
{
    public class ProductNameAlreadyExistsException : Exception
    {
        /// <summary>
        /// Bu ürün ismi daha önce kullanılmış.
        /// </summary>
        public ProductNameAlreadyExistsException()
            : base("Bu ürün ismi daha önce kullanılmış.")
        {

        }

    }
}
