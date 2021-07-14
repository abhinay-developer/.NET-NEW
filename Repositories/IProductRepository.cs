using Flipkart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flipkart.Repositories
{
    interface IProductRepository
    {

         Product createProduct(Product product);

         Product findProductById(int productId);

         List<Product> findAllProducts();

         string deleteProduct(int productId);

         Product updateProduct(int productId, Product product);


         Product findProductByName(string name);



    }
}
