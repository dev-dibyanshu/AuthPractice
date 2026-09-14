using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [Authorize]
        [HttpGet("student")]
        public IActionResult GetStudentData()
        {
            return Ok("This is student data.");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult GetAdminData()
        {
            return Ok("This is admin data.");
        }
    }
}
