namespace GoalTracker.Models
{
    public class RunningGoalStatus
    {
        /// <summary>
        /// Determines if goal is on track to be accomplished
        /// </summary>
        public bool IsOnTrack { get; set; }

        /// <summary>
        /// Determines the distance between where 
        /// </summary>
        public float DistanceDelta { get; set; }

        /// <summary>
        /// The number of kilometers that need to be run on this day of the year to be on track
        /// </summary>
        public float KilometersToBeOnTrack { get; set; }

        /// <summary>
        /// The Total number of kilometers run year-to-date
        /// </summary>
        public float TotalKilometersYearToDate { get; set; }
    }
}
