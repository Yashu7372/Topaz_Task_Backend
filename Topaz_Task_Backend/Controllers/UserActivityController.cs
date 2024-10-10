using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Topaz_Task_Backend.Models;
using Topaz_Task_Backend.Repository;

namespace Topaz_Task_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
            private readonly IUserActivityInterface _userActivityInterface;

            public UserActivityController(IUserActivityInterface userActivityInterface)
            {
                _userActivityInterface = userActivityInterface;
            }

            [HttpPost("form-loaded")]
            public async Task<IActionResult> LogFormLoaded([FromBody] UserActivity activity)
            {
                await _userActivityInterface.LogUserActivity(activity.UserId, "Form Loaded");
                return Ok(new { message = "Form Loaded logged successfully" });
            }

            [HttpPost("form-submitted")]
            public async Task<IActionResult> LogFormSubmitted([FromBody] UserActivity activity)
            {
                await _userActivityInterface.LogUserActivity(activity.UserId, "Form Submitted");
                return Ok(new { message = "Form Submitted logged successfully" });
            }

            [HttpGet("get-activity")]
            public async Task<IActionResult> GetUserActivity(DateTime startDate, DateTime endDate)
            {
                var activities = await _userActivityInterface.GetUserActivity(startDate, endDate);
                return Ok(activities);
            }
        }

    }
