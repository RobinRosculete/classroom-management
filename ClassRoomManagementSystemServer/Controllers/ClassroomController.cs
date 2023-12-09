using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassRoomManagementSystemServer.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using ClassRoomManagementSystemServer.DTO;
using MySqlConnector;
using ClassRoomManagementSystemServer.DTOs;
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
        public IEnumerable<ClassroomEquipment> Get() // API to Get Clasroom with Equipment
        {
            var classroomsWithEquipment = (from c in _db.Classrooms
                                           join ce in _db.Equipment on c.ClassroomId equals ce.ClassroomId
                                           select new ClassroomEquipment()
                                           {
                                               RoomID = c.ClassroomId,
                                               EquipmentID = ce.EquipmentId,
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

        // Api to update the classroom-blackout-hours
        [HttpPut("update-classroom-blackout-hours/{roomID}")]
        public void PutBlackoutHours(int roomID, [FromBody] UpdateBlackoutHours updateModel)
        {
        
               
              var parameters = new[]
                {
                new MySqlParameter("@blackoutHoursStart", updateModel.BlackoutHoursStart),
                new MySqlParameter("@blackoutHoursEnd", updateModel.BlackoutHoursEnd),
                new MySqlParameter("@roomID", roomID)
             };

                _db.Database.ExecuteSqlRaw("UPDATE classroom SET blackout_hours_start = @blackoutHoursStart, blackout_hours_end = @blackoutHoursEnd WHERE classroom_id = @roomID", parameters);
            
  
        }

        // Api to update the equipment type in the database
        [HttpPut("update-classroom-equipment/{equipmentID}")]
        public void PutEquipment(int equipmentID, [FromBody] UpdateEquipment equipmentModel)
        {

            var parameters = new[]
              {
                new MySqlParameter("@equipmentType",equipmentModel.EquipmentType),
                new MySqlParameter("@equipmentID", equipmentID)
             };

            _db.Database.ExecuteSqlRaw("UPDATE equipment SET equipment_type =@equipmentType WHERE equipment_id = @equipmentID;", parameters);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

