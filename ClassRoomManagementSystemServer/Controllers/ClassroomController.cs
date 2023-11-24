using ClassRoomManagementSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomManagementContext _db;
        public ClassroomController(ClassroomManagementContext db)
        {
            _db = db;
          
        }


        // GET: api/Classroom
        [HttpGet]
        public IEnumerable<Classroom> Get()
        {
            return _db.Classrooms.ToList();
        }


        // GET: api/Classroom/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Classroom
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Classroom/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Classroom/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
