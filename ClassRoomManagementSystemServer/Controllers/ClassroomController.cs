using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassRoomManagementSystemServer.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using ClassRoomManagementSystemServer.DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    public class ClassroomController : Controller
    {
        private readonly MydbContext _db;
        public ClassroomController(MydbContext db)
        {
            _db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ClassroomEquipment> Get()
        {
            var classroomsWithEquipment = (from c in _db.Classrooms
                                           join ce in _db.Equipment on c.ClassroomId equals ce.ClassroomId
                                           select new ClassroomEquipment()
                                           {
                                               RoomNum = c.RoomNum,
                                               Capacity = c.Capacity,
                                               DepartmentName = c.DepartmentName,
                                               BlackoutHoursStart = c.BlackoutHoursStart,
                                               BlackoutHoursEnd = c.BlackoutHoursEnd,
                                               EquipmentType = ce.EquipmentType
                                           }).ToList();

            return classroomsWithEquipment;
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

