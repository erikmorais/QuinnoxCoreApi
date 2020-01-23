using Quinnox.OmdbApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace Quinnox.OmdbApi.Interfaces
{
    public interface IOmdbClient
    {
        Task<Movie> GetMovieAsync(int? id = null, int? year = null, string title = "", string plot = "");
        Task<MovieSearch> GetMoviesListAsync(int? year = null, string search = "", string plot = "");
    }
}
