
namespace Quinnox.OmdbApi.Model
{
    public class MovieSearch
    {
        public Movie[] Search { get; set; }
        public int TotalResults { get; set; }
        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
