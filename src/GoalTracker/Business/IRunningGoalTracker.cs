using GoalTracker.Models;
using System.Threading.Tasks;

namespace GoalTracker.Business
{
    public interface IRunningGoalTracker
    {
        Task<RunningGoalStatus> CalculateGoalStatusAsync();
    }
}
