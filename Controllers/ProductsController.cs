using EntityFCAndWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using EntityFCAndWebApi.Models;

namespace EntityFCAndWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(Products products)
        {
            if(products.ProductId == 0)
            {
                _context.Products.Add(products);
            }
            else
            {
                var productsDb = _context.Products.Find(products.ProductId);

                if(productsDb == null)
                    return new JsonResult(NotFound());

                productsDb = products;
            }

            return new JsonResult(Ok(products));
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var resuit = _context.Products.Find(id);

            if(resuit == null)
            {
                return new JsonResult(NotFound());

            }
            return new JsonResult(Ok(resuit));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Products.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Products.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
