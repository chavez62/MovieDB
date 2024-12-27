using MovieDB.Models;
using System.Text.Json;

namespace MovieDB.Services
{
    public class TmdbClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.themoviedb.org/3";


        public TmdbClient(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<MovieResponse> GetNowPlayingMoviesAsync(string language = "en-US", int page = 1)
        {
            var requestUrl = $"{BaseUrl}/movie/now_playing?language={language}&page={page}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MovieResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId, string language = "en-US")
        {
            var requestUrl = $"{BaseUrl}/movie/{movieId}?language={language}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MovieDetails>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<MoviePopular> GetPopularMoviesAsync(string language = "en-US", int page = 1)
        {
            var requestUrl = $"{BaseUrl}/movie/popular?language={language}&page={page}";

            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MoviePopular>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}