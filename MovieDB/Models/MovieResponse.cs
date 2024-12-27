namespace MovieDB.Models
{
    public class MovieResponse : Movie
    {
        public Dates Dates { get; set; }
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }

    public class Dates
    {
        public string Maximum { get; set; }
        public string Minimum { get; set; }
    }
}
