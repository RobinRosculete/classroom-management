using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoomManagementSystemServer.DTOs;
using ClassRoomManagementSystemServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassRoomManagementSystemServer.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {

        private readonly MydbContext _db;
        public RequestController(MydbContext db)
        {
            _db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("section-request")]
        public void PostSectionRequest([FromBody] SectionRequest sectionRequest)
        {
            // Assuming _db is your DbContext instance
            var parameters = new[]
            {
            new MySqlParameter("@DayOfWeek", sectionRequest.Day),
            new MySqlParameter("@StartTime", sectionRequest.Starttime),
            new MySqlParameter("@EndTime", sectionRequest.EndTime),
            new MySqlParameter("@CourseCode", sectionRequest.CourseTitle),
            new MySqlParameter("@Year", sectionRequest.Year),
            new MySqlParameter("@Semester", sectionRequest.Semester),
            new MySqlParameter("@Department", sectionRequest.DepartmentName)
        };

            _db.Database.ExecuteSqlRaw("CALL PerformSectionAndRequestAssignment(@DayOfWeek, @StartTime, @EndTime, @CourseCode, @Year, @Semester, @Department)", parameters);

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

