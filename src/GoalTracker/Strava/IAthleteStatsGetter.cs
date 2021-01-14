using GoalTracker.Models;
using System.Threading.Tasks;

namespace GoalTracker.Strava
{
    public interface IAthleteStatsGetter
    {
        Task<ActivityStats> GetStatsAsync();
    }
}
