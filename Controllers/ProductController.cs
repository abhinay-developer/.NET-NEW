using Flipkart.Models;
using Flipkart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Flipkart.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }

        [HttpPost]
        [Route("api/product/save")]
        public Product saveProduct([FromBody] Product product)
        {
           
            try
            {   
                return productService.saveProduct(product);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return product;
          }//
        [HttpGet]
        [Route("api/product/GetById/{productId}")]
        public Product fetchProductById(int productId)
        {
            try
            {
                return productService.getProductById(productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return productService.getProductById(productId);
        }
        [HttpGet]
        [Route("api/product/GetByName/{name}")]
        public Product fetchProductByName(string name)
        {
            try
            {
                return productService.getProductByName(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return   productService.getProductByName(name);
        }

        [HttpGet]
        [Route("api/product/GetAll")]
        public List<Product> fetchAllProduct()
        {
            try
            {
                return productService.getAllProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        [HttpDelete]
        [Route("api/product/DeleteById/{id}")]
        public string removeProductById(int id)
        {
            try
            {
                return productService.deleteProductById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        [HttpPut]
        [Route("api/product/update/{id}")]
        public Product updateProductById( int id,Product product)
        {
            try
            {
                return productService.updateProductById(id, product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }//class

}//namespace
