using GoalTracker.Models;
using GoalTracker.Strava;
using System;
using System.Threading.Tasks;

namespace GoalTracker.Business
{
    class RunningGoalTracker : IRunningGoalTracker
    {
        private readonly IAthleteStatsGetter _athleteStatsGetter;
        private readonly ApplicationConfiguration _applicationConfiguration;
        

        public RunningGoalTracker(IAthleteStatsGetter athleteStatsGetter,
            ApplicationConfiguration applicationConfiguration)
        {
            _athleteStatsGetter = athleteStatsGetter;
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<RunningGoalStatus> CalculateGoalStatusAsync()
        {
            var athleteStats = await _athleteStatsGetter.GetStatsAsync();

            var totalKilometersRunThisYear = athleteStats.YearToDateRunTotals.Distance / 1000;

            var runningGoal = _applicationConfiguration.RunningGoalInKilometers;
            var dailyKilometersToRunToStayOnTrack = (float)runningGoal / (float)365;

            var dayOfYear = DateTime.Now.DayOfYear;

            var kilometersToBeOnTrack = dailyKilometersToRunToStayOnTrack * dayOfYear;

            var delta = Math.Abs(totalKilometersRunThisYear - kilometersToBeOnTrack);

            return new RunningGoalStatus
            {
                DistanceDelta = delta,
                IsOnTrack = totalKilometersRunThisYear > kilometersToBeOnTrack,
                KilometersToBeOnTrack = kilometersToBeOnTrack,
                TotalKilometersYearToDate = totalKilometersRunThisYear
            };

        }
    }
}
