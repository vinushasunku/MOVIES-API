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
    /// <summary>
    /// Represents the API interface for submitting REST commands 
    /// against movies.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {


        private readonly ILogger<MoviesController> _logger;

        IMoviesBusiness _moviesBusiness;

        /// <summary>
        /// Initializes the movies controller instance.
        /// </summary>
        /// <param name="logger">
        /// The <see cref="ILogger{T}"/> instance for logging.
        /// </param>
        /// <param name="moviesBusiness">
        /// A <see cref="IMoviesBusiness"/> It Interact with dataservice layer to get data from DB.
        public MoviesController(ILogger<MoviesController> logger, IMoviesBusiness moviesBusiness)
        {
            _logger = logger;
            _moviesBusiness = moviesBusiness;
        }

        /// <summary>
        /// Queries a Movies by Title , year, genre
        /// </summary>
        /// <param name="Title"> name to Movie</param>
        /// <param name="Year">  Movie released year</param>
        /// <param name="Genre"> Movie genre</param>
        /// <returns>HTTP Status Code</returns>
        [Route("GetFilterResponse")]
        [HttpGet]
        public ActionResult GetFilterResponse(string Title, string Year,string Genre)
        {           
            try
            {
                MovieInput input = new MovieInput();
                input.Title = (Title != null && !string.IsNullOrEmpty(Title)) ? Title : null;
                input.Year = (Year != null && !string.IsNullOrEmpty(Year)) ? Year : null;
                input.Genre = (Genre != null && !string.IsNullOrEmpty(Genre)) ? Genre : null;
                List<Movies>  moviesResult = _moviesBusiness.GetMoviesByFilter(input);
                if (input.Title == null && input.Year == null && input.Genre == null) {
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
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to process the request");
            }

       

        }
        /// <summary>
        /// Get Top 5 movies mased on total user avg rating 
        /// </summary>
        /// <returns>HTTP Status Code</returns>
        [Route("GetMoviesListByAvgRating")]
        [HttpGet]
        public ActionResult GetMoviesListByAvgRating()
        {

            try
            {
                string type = "AvgRating";
                List<Movies> moviesResult = _moviesBusiness.GetMoviesListByRating(type);
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
                _logger.LogError(string.Format("Error occure in MovieController # GetMoviesListByAvgRating. Exception: {0}", ex));
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to process the request");
               
            }
        }

        /// <summary>
        /// Get Top 5 movies mased on highest rating given by user. 
        /// </summary>
        ///  <param name="name"> logged in user name</param>
        /// <returns>HTTP Status Code</returns>

        [Route("GetMoviesListByHighestRating")]
        [HttpGet]
        public ActionResult GetMoviesListByHighestRating(string name)
        {

            
            try
            {

                if (name == null)
                {
                    return BadRequest("Bad Request");
                }
                string type = "HighestRating";
                List<Movies> moviesResult = _moviesBusiness.GetMoviesListByHighestRating(type, name);
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
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to process the request");
            }

          

        }

        /// <summary>
        /// Add or update Rating by user 
        /// </summary>
        ///  <param name="movieRequest"> Movies information object</param>
        /// <returns>HTTP Status Code</returns>

        [Route("AddMovieRating")]
        [HttpPost]
        public ActionResult AddMovieRating([FromBody]MoviesRequest movieRequest)
        {

            Movies moviesResult = new Movies();
            try
            {
                if (validateMovieRequest(movieRequest))
                {
                    moviesResult = _moviesBusiness.AddRating(movieRequest);
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
                    return StatusCode((int)HttpStatusCode.NotFound, $"User ID Invalid");

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Error occure in MovieController # AddMovieRating. Exception: {0}", ex));
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Unable to process the request ");
            }

        }

        private bool validateMovieRequest(MoviesRequest request)
        {
            bool valid = false;
            try {
                if (request.Title != "string" && request.UserId>0 && request.Rating>0)
                {
                    valid = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Error occure in MovieController # AddMovieRating. Exception: {0}", ex));
               
            }
            return valid;
        }
    }
}
