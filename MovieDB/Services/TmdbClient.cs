using MovieDB.Models;
using System.Text.Json;
namespace MovieDB.Services
{
    public class TmdbClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.themoviedb.org/3";
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

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
            var result = JsonSerializer.Deserialize<MovieResponse>(content, _jsonOptions);
            return result ?? throw new InvalidOperationException("Failed to deserialize now playing movies response");
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId, string language = "en-US")
        {
            var requestUrl = $"{BaseUrl}/movie/{movieId}?language={language}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieDetails>(content, _jsonOptions);
            return result ?? throw new InvalidOperationException("Failed to deserialize movie details response");
        }

        public async Task<MoviePopular> GetPopularMoviesAsync(string language = "en-US", int page = 1)
        {
            var requestUrl = $"{BaseUrl}/movie/popular?language={language}&page={page}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MoviePopular>(content, _jsonOptions);
            return result ?? throw new InvalidOperationException("Failed to deserialize popular movies response");
        }

        public async Task<MovieUpcoming> GetUpcomingMoviesAsync(string language = "en-US", int page = 1)
        {
            var requestUrl = $"{BaseUrl}/movie/upcoming?language={language}&page={page}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieUpcoming>(content, _jsonOptions);
            return result ?? throw new InvalidOperationException("Failed to deserialize upcoming movies response");
        }

        public async Task<MovieResponse> SearchMoviesAsync(string query, string language = "en-US", int page = 1)
        {
            var requestUrl = $"{BaseUrl}/search/movie?query={query}&language={language}&page={page}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieResponse>(content, _jsonOptions);
            return result ?? throw new InvalidOperationException("Failed to deserialize search movies response");
        }
    }
}
