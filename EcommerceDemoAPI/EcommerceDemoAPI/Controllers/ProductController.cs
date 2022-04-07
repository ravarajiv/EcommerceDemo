using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceDemoAPI.Models;
using System.Web.Script.Serialization;

namespace EcommerceDemoAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/product
        public HttpResponseMessage  Get()
        {
            ProductClass pcm = new ProductClass();
            return Request.CreateResponse(HttpStatusCode.OK, pcm.GetProduct(), Configuration.Formatters.JsonFormatter);
            //return Ok(pcm.GetProduct());
           
          
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            ProductClass pcm = new ProductClass();
            return Request.CreateResponse(HttpStatusCode.OK, pcm.GetProduct(id), Configuration.Formatters.JsonFormatter);
            //return Ok(pcm.GetProduct());
           
        }

        // POST api/product
        public void Post([FromBody]string value)
        {
            try
            {

            
            
           // string JsonString = @"{'ProductName':'Car2','ProductDescription':'Car2 Description','ProdCatId':'1'}";
            string JsonString = value;
            var Serializer = new JavaScriptSerializer();
            ProductClass ObjProduct = Serializer.Deserialize<ProductClass>(JsonString);
            ObjProduct.AddProduct(ObjProduct);
            }
            catch (Exception ex)
            {
                //Can Logging
                throw;
            }

        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {
            try
            {

            
            string JsonString = value;
            var Serializer = new JavaScriptSerializer();
            ProductClass ObjProduct = Serializer.Deserialize<ProductClass>(JsonString);
            ObjProduct.ProductID = id;
            ObjProduct.EditProduct(ObjProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
            try
            {
                ProductClass objProduct = new ProductClass();
                objProduct.DeleteProduct(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
