using System.Text.Json.Serialization;

namespace GoalTracker.Models
{
    // see https://developers.strava.com/docs/reference/#api-models-ActivityStats

    public class ActivityStats
    {
        /// <summary>
        ///  The longest distance ridden by the athlete.
        /// </summary>
        [JsonPropertyName("biggest_ride_distance")]
        public double? BiggestRideDistance { get; set; }

        /// <summary>
        ///  The highest climb ridden by the athlete.
        /// </summary>
        [JsonPropertyName("biggest_climb_elevation_gain")]
        public double? BiggestClimbElevationGain { get; set; }

        /// <summary>
        ///  The recent (last 4 weeks) ride stats for the athlete.
        /// </summary>
        [JsonPropertyName("recent_ride_totals")]
        public ActivityTotal RcentRideTotals { get; set; }

        /// <summary>
        ///  The recent (last 4 weeks) run stats for the athlete.
        /// </summary>
        [JsonPropertyName("recent_run_totals")]
        public ActivityTotal RcentRunTotals { get; set; }

        /// <summary>
        ///  The recent (last 4 weeks) swim stats for the athlete.
        /// </summary>
        [JsonPropertyName("recent_swim_totals")]
        public ActivityTotal RcentSwimTotals { get; set; }

        /// <summary>
        ///  The year to date ride stats for the athlete. 
        /// </summary>
        [JsonPropertyName("ytd_ride_totals")]
        public ActivityTotal YearToDateRideTotals { get; set; }

        /// <summary>
        ///  The year to date run stats for the athlete. 
        /// </summary>
        [JsonPropertyName("ytd_run_totals")]
        public ActivityTotal YearToDateRunTotals { get; set; }

        /// <summary>
        ///  The year to date swim stats for the athlete.
        /// </summary>
        [JsonPropertyName("ytd_swim_totals")]
        public ActivityTotal YearToDateSwimTotals { get; set; }

        /// <summary>
        ///  The all time ride stats for the athlete.
        /// </summary>
        [JsonPropertyName("all_ride_totals")]
        public ActivityTotal AllRideTotals { get; set; }

        /// <summary>
        ///  The all time run stats for the athlete.
        /// </summary>
        [JsonPropertyName("all_run_totals")]
        public ActivityTotal AllRunTotals { get; set; }

        /// <summary>
        ///  The all time swim stats for the athlete.
        /// </summary>
        [JsonPropertyName("all_swim_totals")]
        public ActivityTotal AllSwimTotals { get; set; }

    }

    public class ActivityTotal
    {
        /// <summary>
        /// The number of activities considered in this total.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// The total distance covered by the considered activities, in meters
        /// </summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        /// <summary>
        ///  The total moving time of the considered activities.
        /// </summary>
        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        /// <summary>
        ///  The total elapsed time of the considered activities.
        /// </summary>
        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        /// <summary>
        ///  The total elevation gain of the considered activities.
        /// </summary>
        [JsonPropertyName("elevation_gain")]
        public float ElevationGain { get; set; }

        /// <summary>
        ///  The total number of achievements of the considered activities.
        /// </summary>
        [JsonPropertyName("achievement_count")]
        public int AchievementCount { get; set; }
    }
}
