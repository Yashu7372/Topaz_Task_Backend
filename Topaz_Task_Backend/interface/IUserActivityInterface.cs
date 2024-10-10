using Topaz_Task_Backend.Models;
    public interface IUserActivityInterface
    {
        Task LogUserActivity(int userId, string activityType);
        Task<List<UserActivity>> GetUserActivity(DateTime startDate, DateTime endDate);
    }

