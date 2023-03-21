using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        public ApplicationDbContext dbContext;
        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var attendance=new Attendance
            {
                CourseId=courseId,
                AttendeeId=User.Identity.GetUserId()
            };
            dbContext.Attendances.Add(attendance);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
