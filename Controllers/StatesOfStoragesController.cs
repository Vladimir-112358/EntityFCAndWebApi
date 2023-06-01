using EntityFCAndWebApi.Data;
using EntityFCAndWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFCAndWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesOfStoragesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatesOfStoragesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(StatesOfStorages statesOfStorages)
        {
            if (statesOfStorages.StateOfStorageId == 0)
            {
                _context.StatesOfStorages.Add(statesOfStorages);
            }
            else
            {
                var stateOfStoragesDb = _context.StatesOfStorages.Find(statesOfStorages.StateOfStorageId);

                if (stateOfStoragesDb == null)
                    return new JsonResult(NotFound());

                stateOfStoragesDb = statesOfStorages;
            }

            return new JsonResult(Ok(statesOfStorages));
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var resuit = _context.StatesOfStorages.Find(id);

            if (resuit == null)
            {
                return new JsonResult(NotFound());

            }
            return new JsonResult(Ok(resuit));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.StatesOfStorages.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.StatesOfStorages.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
