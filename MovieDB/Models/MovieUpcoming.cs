using System.Text.Json.Serialization;

namespace MovieDB.Models
{
    public class MovieUpcoming
    {
        [JsonPropertyName("dates")]
        public Dates Dates { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

}
