using GoalTracker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using GoalTracker.Strava;
using GoalTracker.Business;

namespace GoalTracker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appConfiguration = GetConfiguration();

            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
                .AddSingleton<IAthleteStatsGetter, AthleteStatsGetter>()
                .AddSingleton<IRunningGoalTracker, RunningGoalTracker>()
                .AddSingleton(appConfiguration)
                .BuildServiceProvider();


            var runningGoalTracker = serviceProvider.GetService<IRunningGoalTracker>();
            var runningGoalStatus = await runningGoalTracker.CalculateGoalStatusAsync();

            Console.WriteLine($"Running Goal status");
            Console.WriteLine($"Is On Track? {runningGoalStatus.IsOnTrack } ");
            Console.WriteLine($"At this point I should have run {runningGoalStatus.KilometersToBeOnTrack} but have run {runningGoalStatus.TotalKilometersYearToDate}");
            Console.WriteLine($"Difference of {runningGoalStatus.DistanceDelta} kilometers");
        }

        private static ApplicationConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            return configuration
                .GetSection("ApplicationConfiguration")
                .Get<ApplicationConfiguration>();
        }
    }
}
