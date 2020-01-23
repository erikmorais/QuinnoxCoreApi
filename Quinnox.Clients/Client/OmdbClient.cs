using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Quinnox.OmdbApi.Interfaces;
using Quinnox.OmdbApi.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Quinnox.OmdbApi.Client
{
    public class OmdbClient : IOmdbClient
    {
        private readonly HttpClient _httpClient;


        // TODO: Move apiKey to settings and inject it
        //  private string _apiKey = "b473dec9";
        private readonly IOmdbKey _omdbKey;


        public OmdbClient(HttpClient httpClient, IOmdbKey omdbKey)
        {
            _httpClient = httpClient;
            _omdbKey = omdbKey;
        }

        private string MovieQueryBuilder(int? id, int? year, string title = "", string plot = "")
        {
            if (id == null && title == "")
                throw new ArgumentNullException("missing id and/or title parameter values");

            if (_omdbKey.Key == null || _omdbKey.Key == "")
                throw new ArgumentNullException("missing ombdKey");

            string query = "?";

            if (id != null)
                query += $"id{id}&";
            if (year != null)
                query += $"y={year}&";
            if (title != "")
                query += $"t={title}&";
            if (plot != "")
                query += $"p={plot}&";

            query += $"apikey={_omdbKey.Key}";

            return query;
        }

        private string MoviesListQueryBuilder(int? year, string search = "", string plot = "")
        {
            if (search == "")
                throw new ArgumentNullException("missing id and/or search parameter values");

            if (_omdbKey.Key == null || _omdbKey.Key == "")
                throw new ArgumentNullException("missing ombdKey");

            string query = "?";

            if (search != "")
                query += $"s={search}&";

            if (year != null)
                query += $"y={year}&";

            if (plot != "")
                query += $"p={plot}&";

            query += $"apikey={_omdbKey.Key}";

            return query;
        }

        public async Task<Movie> GetMovieAsync(int? id, int? year = null, string title = "", string plot = "")
        {
            var response = await _httpClient.GetStringAsync(MovieQueryBuilder(id, year, title, plot));

            return JsonConvert.DeserializeObject<Movie>(response, new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    var currentError = args.ErrorContext.Error.Message;
                    args.ErrorContext.Handled = true;
                }
            });
        }
        // TODO: convert plot to enum
        public Task<MovieSearch> GetMoviesListAsync(int? year = null, string search = "", string plot = "")
        {
            return SearchAsync<MovieSearch>(year, search, plot);
        }

        //TODO: Refactory >> move it to a generic service
        private async Task<T> SearchAsync<T>(int? year = null, string search = "", string plot = "")
        {
            var response = await _httpClient.GetStringAsync(MoviesListQueryBuilder(year, search, plot));

            return JsonConvert.DeserializeObject<T>(response, new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    var currentError = args.ErrorContext.Error.Message;
                    args.ErrorContext.Handled = true;
                }
            });
        }
    }
}
