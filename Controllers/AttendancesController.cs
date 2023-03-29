using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
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
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId=User.Identity.GetUserId();
            
            if (dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The attendance already exists !");
            var attendance=new Attendance
            {
                CourseId=attendanceDto.CourseId,
                AttendeeId=userId
            };
            dbContext.Attendances.Add(attendance);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
