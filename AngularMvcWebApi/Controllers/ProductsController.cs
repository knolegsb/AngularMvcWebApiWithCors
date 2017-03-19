using AngularMvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace AngularMvcWebApi.Controllers
{
    [EnableCorsAttribute("http://localhost:15665", "*", "*")]
    public class ProductsController : ApiController
    {
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }

        [ResponseType(typeof(Product))]
        [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();

                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/products
        public void Post([FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/products/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var updateProduct = productRepository.Save(id, product);
        }

        // DELETE: api/products/5
        public void Delete(int id)
        {

        }
    }
}
