using GoalTracker.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoalTracker.Strava
{
    public class AthleteStatsGetter : IAthleteStatsGetter
    {
        private readonly ApplicationConfiguration _applicationConfiguration;

        public AthleteStatsGetter(ApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        private const string AthleteStatsUrl = "https://www.strava.com/api/v3/athletes/{0}/stats";

        public async Task<ActivityStats> GetStatsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                    ("Bearer", _applicationConfiguration.AccessToken);

                var url = string.Format(AthleteStatsUrl, _applicationConfiguration.AthleteId);

                using (var httpResponse = await httpClient.GetAsync(url))
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var stats = JsonSerializer.Deserialize<ActivityStats>(responseContent);

                    return stats;
                }
            }
        }
    }
}
