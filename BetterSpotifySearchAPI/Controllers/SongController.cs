using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BetterSpotifySearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SongController : ControllerBase
    {
        private readonly IAccessService _AccessService;

        public SongController(IAccessService accessService){
            _AccessService = accessService;
        }

        [HttpGet]
        public async Task<IActionResult> SharedServiceTest()
        {
            return(Ok(_AccessService.GetTestToken()));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Search(string? name)
        {
            using HttpClient httpClient = new HttpClient();
            string? _accessToken = _AccessService.GetAccessToken();

            if(name == null)
            {
                return BadRequest("No search value");
            }
            StringBuilder requestBuilder = new StringBuilder("https://api.spotify.com/v1/search?");
            requestBuilder.Append("q=" + Uri.EscapeDataString(name));
            requestBuilder.Append("&type=track");
            requestBuilder.Append("&limit=10");
            string requestString = requestBuilder.ToString();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestString);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return BadRequest(response);
        }

        [Route("{songID}")]
        public async Task<IActionResult> Features(string? songID){
            using HttpClient httpClient = new HttpClient();
            string? _accessToken = _AccessService.GetAccessToken();

            if(songID == null){
                return BadRequest("No song given");
            }

            StringBuilder requestBuilder = new StringBuilder("https://api.spotify.com/v1/audio-features/");
            requestBuilder.Append(songID);
            string requestString = requestBuilder.ToString();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestString);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return BadRequest(response);
        }

        public async Task<IActionResult> SearchBy(string? seed_artists, string? seed_genres, string? seed_songs,
                                                  float? min_acousticness, float? max_acousticness, float? target_acousticness,
                                                  float? min_danceability, float? max_danceability, float? target_danceability,
                                                  int? min_duration, int? max_duration, int? target_duration,
                                                  float? min_energy, float? max_energy, float? target_energy,
                                                  float? min_instrumentalness, float? max_instrumentalness, float? target_instrumentalness,
                                                  int? min_key, int? max_key, int? target_key,
                                                  float? min_liveness, float? max_liveness, float? target_liveness,
                                                  float? min_loudness, float? max_loudness, float? target_loudness,
                                                  int? min_mode, int? max_mode, int? target_mode,
                                                  int? min_popularity, int? max_popularity, int? target_popularity,
                                                  float? min_speechiness, float? max_speechiness, float? target_speechiness,
                                                  float? min_tempo, float? max_tempo, float? target_tempo,
                                                  int? min_time_signature, int? max_time_signature, int? target_time_signature,
                                                  float? min_valence, float? max_valence, float? target_valence)
        {
            using HttpClient httpClient = new HttpClient();
            string? _accessToken = _AccessService.GetAccessToken();

            bool all_null = true;

            StringBuilder requestBuilder = new StringBuilder("https://api.spotify.com/v1/recommendations?");
            requestBuilder.Append("limit=" + 10);
            if(seed_artists != null){
                requestBuilder.Append("&=seed_artists" + seed_artists);
                all_null = false;
            }
            if(seed_genres != null){
                requestBuilder.Append("&=seed_genres" + seed_genres);
                all_null = false;
            }
            if(seed_songs != null){
                requestBuilder.Append("&=seed_tracks" + seed_songs);
                all_null = false;
            }
            if(min_acousticness != null){
                requestBuilder.Append("&=min_acousticness" + min_acousticness);
                all_null = false;
            }
            if(max_acousticness != null){
                requestBuilder.Append("&=max_acousticness" + max_acousticness);
                all_null = false;
            }
            if(target_acousticness != null){
                requestBuilder.Append("&=target_acousticness" + target_acousticness);
                all_null = false;
            }
            if(min_danceability != null){
                requestBuilder.Append("&=min_danceability" + min_danceability);
                all_null = false;
            }
            if(max_danceability != null){
                requestBuilder.Append("&=max_danceability" + max_danceability);
                all_null = false;
            }
            if(target_danceability != null){
                requestBuilder.Append("&=target_danceability" + target_danceability);
                all_null = false;
            }
            if(min_duration != null){
                requestBuilder.Append("&=min_duration_ms" + min_duration);
                all_null = false;
            }
            if(max_duration != null){
                requestBuilder.Append("&=max_duration_ms" + max_duration);
                all_null = false;
            }
            if(target_duration != null){
                requestBuilder.Append("&=target_duration_ms" + target_duration);
                all_null = false;
            }
            if(min_energy != null){
                requestBuilder.Append("&=min_energy" + min_energy);
                all_null = false;
            }
            if(max_energy != null){
                requestBuilder.Append("&=max_energy" + max_energy);
                all_null = false;
            }
            if(target_energy != null){
                requestBuilder.Append("&=target_energy" + target_energy);
                all_null = false;
            }
            if(min_instrumentalness != null){
                requestBuilder.Append("&=min_instrumentalness" + min_instrumentalness);
                all_null = false;
            }
            if(max_instrumentalness != null){
                requestBuilder.Append("&=max_instrumentalness" + max_instrumentalness);
                all_null = false;
            }
            if(target_instrumentalness != null){
                requestBuilder.Append("&=target_instrumentalness" + target_instrumentalness);
                all_null = false;
            }
            if(min_key != null){
                requestBuilder.Append("&=min_key" + min_key);
                all_null = false;
            }
            if(max_key != null){
                requestBuilder.Append("&=max_key" + max_key);
                all_null = false;
            }
            if(target_key != null){
                requestBuilder.Append("&=target_key" + target_key);
                all_null = false;
            }
            if(min_liveness != null){
                requestBuilder.Append("&=min_liveness" + min_liveness);
                all_null = false;
            }
            if(max_liveness != null){
                requestBuilder.Append("&=max_liveness" + max_liveness);
                all_null = false;
            }
            if(target_liveness != null){
                requestBuilder.Append("&=target_liveness" + target_liveness);
                all_null = false;
            }
            if(min_loudness != null){
                requestBuilder.Append("&=min_loudness" + min_loudness);
                all_null = false;
            }
            if(max_loudness != null){
                requestBuilder.Append("&=max_loudness" + max_loudness);
                all_null = false;
            }
            if(target_loudness != null){
                requestBuilder.Append("&=target_loudness" + target_loudness);
                all_null = false;
            }
            if(min_mode != null){
                requestBuilder.Append("&=min_mode" + min_mode);
                all_null = false;
            }
            if(max_mode != null){
                requestBuilder.Append("&=max_mode" + max_mode);
                all_null = false;
            }
            if(target_mode != null){
                requestBuilder.Append("&=target_mode" + target_mode);
                all_null = false;
            }
            if(min_popularity != null){
                requestBuilder.Append("&=min_popularity" + min_popularity);
                all_null = false;
            }
            if(max_popularity != null){
                requestBuilder.Append("&=max_popularity" + max_popularity);
                all_null = false;
            }
            if(target_popularity != null){
                requestBuilder.Append("&=target_popularity" + target_popularity);
                all_null = false;
            }
            if(min_speechiness != null){
                requestBuilder.Append("&=min_speechiness" + min_speechiness);
                all_null = false;
            }
            if(max_speechiness != null){
                requestBuilder.Append("&=max_speechiness" + max_speechiness);
                all_null = false;
            }
            if(target_speechiness != null){
                requestBuilder.Append("&=target_speechiness" + target_speechiness);
                all_null = false;
            }
            if(min_tempo != null){
                requestBuilder.Append("&=min_tempo" + min_tempo);
                all_null = false;
            }
            if(max_tempo != null){
                requestBuilder.Append("&=max_tempo" + max_tempo);
                all_null = false;
            }
            if(target_tempo != null){
                requestBuilder.Append("&=target_tempo" + target_tempo);
                all_null = false;
            }
            if(min_time_signature != null){
                requestBuilder.Append("&=min_time_signature" + min_time_signature);
                all_null = false;
            }
            if(max_time_signature != null){
                requestBuilder.Append("&=max_time_signature" + max_time_signature);
                all_null = false;
            }
            if(target_time_signature != null){
                requestBuilder.Append("&=target_time_signature" + target_time_signature);
                all_null = false;
            }
            if(min_valence != null){
                requestBuilder.Append("&=min_valence" + min_valence);
                all_null = false;
            }
            if(max_valence != null){
                requestBuilder.Append("&=max_valence" + max_valence);
                all_null = false;
            }
            if(target_valence != null){
                requestBuilder.Append("&=target_valence" + target_valence);
                all_null = false;
            }
            if(all_null){
                return BadRequest("No search criteria");
            }
            string requestString = requestBuilder.ToString();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestString);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            return BadRequest(response);
        }
    }
}
