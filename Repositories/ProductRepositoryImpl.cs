using Flipkart.Connections;
using Flipkart.Models;
using Flipkart.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flipkart.Repositories
{
    public class ProductRepositoryImpl : IProductRepository
    {
        SqlConnection con = null;

        public Product createProduct(Product product)
        {

            try
            {
                con = DBConnection.CreateConnection();
                con.Open();
                //SqlCommand is a class
                SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTS_TBL(NAME,DESCRIPTION,PRICE)values('" + product.NAME + "','" + product.DESCRIPTION + "','" +product.PRICE+ "')", con);
                 cmd.ExecuteNonQuery();
                con.Close();

                return product;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return product;
        }

        public string deleteProduct(int productId)
        {
            try
            {
                con = DBConnection.CreateConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE  FROM PRODUCTS_TBL WHERE PRODUCT_ID=" + productId, con);
                //creating object for Product
                SqlDataReader sdr = cmd.ExecuteReader();
                return "Product Deleted Sucessfully:" + productId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<Product> findAllProducts()
        {
            List<Product> productsList = new List<Product>();

            try
            {
                Product theProduct = new Product();

                con = DBConnection.CreateConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS_TBL", con);
                //creating object for Product
                
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    productsList.Add(theProduct);
                    
                   
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return productsList;

        }
        public Product findProductById(int productId)
        {
            try
            {
                con = DBConnection.CreateConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS_TBL WHERE PRODUCT_ID=" + productId, con);
               //creating object for Product
                Product theProduct = new Product();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    con.Close();
                    return theProduct;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Product findProductByName(string name)
        {
            try
            {
                con = DBConnection.CreateConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS_TBL WHERE 'NAME'=" + name, con);
                //creating object for Product
                Product theProduct = new Product();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    theProduct = new Product();
                    theProduct.PRODUCT_ID = Convert.ToInt32(sdr["PRODUCT_ID"]);
                    theProduct.NAME = Convert.ToString(sdr["NAME"]);
                    theProduct.DESCRIPTION = Convert.ToString(sdr["DESCRIPTION"]);
                    theProduct.PRICE = Convert.ToDecimal(sdr["PRICE"]);
                    con.Close();
                    return theProduct;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Product updateProduct(int productId, Product product)
        {
            try
            {
                con = DBConnection.CreateConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE PRODUCTS_TBL SET  NAME = '"+product.NAME + "', DESCRIPTION = '" + product.DESCRIPTION+ "', PRICE = '" + product.PRICE+"' WHERE PRODUCT_ID ="+ productId, con);
                //creating object for Product
                SqlDataReader sdr = cmd.ExecuteReader();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    

    }
}