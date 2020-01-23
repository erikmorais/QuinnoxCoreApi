using Newtonsoft.Json;
using NUnit.Framework;
using Quinnox.OmdbApi.Client;
using Quinnox.OmdbApi.Interfaces;
using Quinnox.OmdbApi.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        private HttpClient _httpClient;
        private IOmdbClient _omdbClient;

        [SetUp]
        public void Setup()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://www.omdbapi.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _omdbClient = new OmdbClient(_httpClient, new OmdbKey("b473dec9"));

        }
        [Test]
        public async Task TestGetByTitleClent()
        {
            var move = await _omdbClient.GetMovieAsync(title: "Batman");

            Assert.IsNotNull(move);
            Assert.AreEqual("Batman", move.Title);
        }

        [Test]
        public async Task TestGetListOfMoviesByTitle()
        {
            var movies =await _omdbClient.GetMoviesListAsync(search: "Game of Thrones");

            Assert.IsNotNull(movies);
            Assert.AreEqual("Game of Thrones", movies.Search[0].Title);
        }

        [Test]
        public async Task TestGetByTitleClentUsingHttpClient()
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://www.omdbapi.com?t=Batman&apikey=b473dec9");
                using (HttpContent content = response.Content)
                {
                    string movies = content.ReadAsStringAsync().Result;
                    var search = JsonConvert.DeserializeObject<Movie>(movies); //ok
                    var search2 = JsonConvert.DeserializeObject<MovieSearch>(movies);
                }
            }
        }

        [TearDown]
        public void DisposeClient()
        {
            _httpClient.Dispose();
        }
    }
}