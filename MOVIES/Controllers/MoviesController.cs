using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOVIES.Business.Interfaces;
using MOVIES.Entities.Movies;
using Newtonsoft.Json.Linq;

namespace MOVIES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {


        private readonly ILogger<MoviesController> _logger;

        IMoviesBusiness _moviesBusiness;

        public MoviesController(ILogger<MoviesController> logger, IMoviesBusiness moviesBusiness)
        {
            _logger = logger;
            _moviesBusiness = moviesBusiness;
        }

        
        [Route("GetFilterResponse")]
        [HttpGet]
        public ActionResult GetFilterResponse(string Title, string Year,string Genre)
        {
            List<Movies> moviesResult = null;
            try
            {
                MovieInput input = new MovieInput();
                if (!string.IsNullOrEmpty(Title))
                {
                    input.Title = Title;
                }
                if (!string.IsNullOrEmpty(Year))
                {
                    input.Year = Year;
                }
                if (!string.IsNullOrEmpty(Genre))
                {
                    input.Genre = Genre;
                  
                }

                if (input != null)
                {
                    moviesResult = _moviesBusiness.GetMoviesByFilter(input);
                }
                else
                {
                    return BadRequest("Bad Request");
                }
               
                if (moviesResult != null)
                {
                    return Ok(moviesResult);
                }
                else
                { 
                    return StatusCode((int)HttpStatusCode.NotFound, $"Movies Not found");
                }
    
            }
            catch (Exception ex)
            {
                
                _logger.LogError(string.Format("Error occure in MovieController # GetFilterResponse. Exception: {0}", ex));
                return BadRequest("Bad Request");
            }

       

        }

        [Route("GetMoviesListByAvgRating")]
        [HttpGet]
        public ActionResult GetMoviesListByAvgRating()
        {

            List<Movies> moviesResult = null;
            try
            {
                string type = "AvgRating";
                moviesResult = _moviesBusiness.GetMoviesListByRating(type);
                if (moviesResult != null)
                {
                    return Ok(moviesResult);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, $"Movies Not found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Error occure in MovieController # GetFilterResponse. Exception: {0}", ex));
                return BadRequest("Bad Request");
            }

            

        }

        [Route("GetMoviesListByHighestRating")]
        [HttpGet]
        public ActionResult GetMoviesListByHighestRating(string name)
        {

            List<Movies> moviesResult = null;
            try
            {
                string type = "HighestRating";
                moviesResult = _moviesBusiness.GetMoviesListByHighestRating(type,name);
                if (moviesResult != null)
                {
                    return Ok(moviesResult);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, $"Movies Not found");
                }

            }
            catch (Exception ex)
            {
               
                _logger.LogError(string.Format("Error occure in MovieController # GetMoviesListByHighestRating. Exception: {0}", ex));
                return BadRequest("Bad Request");
            }

          

        }

        [Route("AddMovieRating")]
        [HttpPost]
        public ActionResult AddMovieRating([FromBody]Movies movieRequest)
        {

            Movies moviesResult = new Movies();
            try
            {
                if (movieRequest != null) {
                    moviesResult = _moviesBusiness.AddRating(movieRequest);
                }
               
                if (moviesResult != null)
                {
                    return Ok(moviesResult);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, $"User ID Invalid");

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Error occure in MovieController # AddMovieRating. Exception: {0}", ex));
                return BadRequest("Bad Request");
            }

            return BadRequest("Bad Request");

        }
    }
}
