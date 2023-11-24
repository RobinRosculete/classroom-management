using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoomManagementSystemServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {

        private readonly ClassroomManagementContext _db;
        public BuildingController(ClassroomManagementContext db)
        {
            _db = db;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Building> GetBuildingsWithDepartmentsAndClassrooms()
        {
            var buildingsWithDepartmentsAndClassrooms = _db.Buildings.ToList();
              

            return buildingsWithDepartmentsAndClassrooms;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

