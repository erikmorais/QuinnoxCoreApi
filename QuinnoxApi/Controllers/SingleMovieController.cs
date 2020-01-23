//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Quinnox.OmdbApi.Interfaces;
//using Quinnox.OmdbApi.Model;
//using Quinnox.WebApi.ViewModel;

//namespace QuinnoxApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SingleMovieController : ControllerBase
//    {
//        private readonly IOmdbClient movieService;
//        private readonly ILogger<SingleMovieController> logger;

//        public SingleMovieController(IOmdbClient movieService, ILogger<SingleMovieController> logger)
//        {
//            this.movieService = movieService;
//            this.logger = logger;
//        }

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<SingleMovie>> Get(string s, string plot, int? year)
//        {
//            SingleMovie movie = null;
//            try
//            {
//                logger.LogTrace("query requested: t = {s}  plot = {plot} year = {year} ");

//                movie = await movieService.GetMovieAsync(title: s, plot: plot, year: year);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError("A Error has ocurred: " + ex.ToString());

//                movie = new SingleMovie();
             
//                return StatusCode(StatusCodes.Status404NotFound, movie);
//            }

//            if (movie != null)
//            {
//                logger.LogWarning($"Invalid query search: s = {s}  plot = {plot} year = {year} ");
//                return movie;
//            }

//            return StatusCode(StatusCodes.Status404NotFound, "Not Found");

//        }

//    }
//}
