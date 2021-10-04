using MOVIES.DataServices.DBContext;
using MOVIES.Entities.Movies;
using MOVIES.Entities.Responses;
using System;
using System.Collections.Generic;

namespace MOVIES.DataServices
{
    public class MoviesFacade
    {

        IMoviesProvider _moviesProvider;

        public MoviesFacade(IMoviesProvider moviesProvider)
        {
            // _logger = logger;
            _moviesProvider = moviesProvider;
        }
        public  DataServiceResponse GetMoviesByFilter(MovieInput input)
        {
            DataServiceResponse response = null;
            try 
            {
                List<Movies> movies = _moviesProvider.get(input);

                return response;
                
                //need to get from Json file
            } 
            catch (Exception ex) 
            {
            }
            return response;
        }
    }
}
