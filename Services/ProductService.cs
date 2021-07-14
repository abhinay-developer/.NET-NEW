using Flipkart.Models;
using Flipkart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipkart.Services
{
    public class ProductService
    {
        private ProductRepositoryImpl productRepositoryImpl;
        public ProductService()
        {
            productRepositoryImpl = new ProductRepositoryImpl();

        }

        public Product  saveProduct(Product product)
        {

            return productRepositoryImpl.createProduct(product);
        }

        public Product getProductById(int productId)
        {
            return productRepositoryImpl.findProductById(productId);
        }

        public Product getProductByName(string name)
        {
            return productRepositoryImpl.findProductByName(name);
        }


        public List<Product> getAllProducts()
        {
            return productRepositoryImpl.findAllProducts();
        }

        public string  deleteProductById(int id)
        {
            return productRepositoryImpl.deleteProduct(id);
        }

        public Product  updateProductById(int id,Product product)
        {
            return productRepositoryImpl.updateProduct(id,product);
        }
    }
}