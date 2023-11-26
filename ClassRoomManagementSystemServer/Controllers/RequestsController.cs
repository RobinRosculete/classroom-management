using ClassRoomManagementSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase

    {
        private readonly ClassroomManagementContext _db;
        public RequestsController(ClassroomManagementContext db)
        {
            _db = db;

        }


        // GET: api/Requests
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return _db.Requests.ToList();
        }

        // GET api/<RequestsController>/5
        //Name can't have the same name as other controllers
        [HttpGet("{id}", Name = "GetRequests")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RequestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RequestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
