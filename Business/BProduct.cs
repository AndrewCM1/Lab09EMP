using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        public List<Product> GetAllProducts()
        {
            DProduct dataProduct = new DProduct();
            List<Product> allProducts = dataProduct.GetAllP();
            return allProducts;
        }
    }
}
