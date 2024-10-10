namespace Topaz_Task_Backend.Models
{
    public class UserActivity
    {
        public int UserId { get; set; }
        public string ActivityType { get; set; }
        public DateTime ActivityTime { get; set; }
    }
}
