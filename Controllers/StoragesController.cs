using EntityFCAndWebApi.Data;
using EntityFCAndWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFCAndWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoragesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoragesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]

        public JsonResult CreateEdit(Storages storages)
        {
            if(storages.StorageId == 0) 
            {
                _context.Storages.Add(storages);
            }
            else
            {
                var storagesDb = _context.Storages.Find(storages.StorageId);

                if(storagesDb == null) 
                {
                    return new JsonResult(NotFound());

                }
                storagesDb = storages;
            }

            return new JsonResult(Ok(storages));
        }
        [HttpGet]

        public JsonResult Get(int id)
        {
            var resuit = _context.Storages.Find(id);

            if (resuit == null)
            {
                return new JsonResult(NotFound());

            }
            return new JsonResult(Ok(resuit));
        }

        //getAll
        [HttpGet]
        public JsonResult GetAll() 
        { 
            var result = _context.Storages.ToList();

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Storages.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Storages.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
