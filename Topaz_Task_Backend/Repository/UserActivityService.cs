using Microsoft.Data.SqlClient;
using System.Data;
using Topaz_Task_Backend.Models;

namespace Topaz_Task_Backend.Repository
{
    public class UserActivityService : IUserActivityInterface
    {
        private readonly IConfiguration _configuration;

        public UserActivityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task LogUserActivity(int userId, string activityType)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand("InsertUserActivity", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ActivityType", activityType);

                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<UserActivity>> GetUserActivity(DateTime startDate, DateTime endDate)
        {
            List<UserActivity> activities = new List<UserActivity>();

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand("GetUserActivity", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                conn.Open();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        activities.Add(new UserActivity
                        {
                            UserId = reader.GetInt32(0),
                            ActivityType = reader.GetString(1),
                            ActivityTime = reader.GetDateTime(2)
                        });
                    }
                }
            }

            return activities;
        }
    }

}
