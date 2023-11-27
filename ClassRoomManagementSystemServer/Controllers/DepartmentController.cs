using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassRoomManagementSystemServer.Models;

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly MydbContext _db;
        public DepartmentController(MydbContext db)
        {
            _db = db;
        }


        // GET: api/Department
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _db.Departments.ToList();
        }

        // GET: api/Department/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Department
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
