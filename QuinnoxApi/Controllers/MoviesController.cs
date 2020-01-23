using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quinnox.OmdbApi.Interfaces;
using Quinnox.OmdbApi.Model;
using Quinnox.WebApi.ViewModel;

namespace QuinnoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IOmdbClient movieService;
        private readonly ILogger<MoviesController> logger;

        public MoviesController(IOmdbClient movieService, ILogger<MoviesController> logger)
        {
            this.movieService = movieService;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieSearch>> Get(string s, string plot, int? year)
        {
            MovieSearch movies = null;
            try
            {
                logger.LogTrace("query requested: s = {s}  plot = {plot} year = {year} ");

                movies = await movieService.GetMoviesListAsync(search: s, plot: plot, year: year);
            }
            catch (Exception ex)
            {
                logger.LogError("A Error has ocurred: " + ex.ToString());

                movies = new MovieSearch();
                movies.Error = "Internal Server Error";
                return StatusCode(StatusCodes.Status404NotFound, movies);
            }

            if (movies != null)
            {
                logger.LogWarning($"Invalid query search: s = {s}  plot = {plot} year = {year} ");
                return movies;
            }

            return StatusCode(StatusCodes.Status404NotFound, "Not Found");

        }

    }
}
