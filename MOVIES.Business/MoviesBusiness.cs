using MOVIES.Business.Interfaces;
using MOVIES.DataServices;
using MOVIES.DataServices.DBContext;
using MOVIES.Entities.Movies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace MOVIES.Business
{
    public class MoviesBusiness : IMoviesBusiness
    {

        IMoviesProvider _moviesProvider;

        public MoviesBusiness(IMoviesProvider moviesProvider)
        {
            // _logger = logger;
            _moviesProvider = moviesProvider;
        }

        public List<Movies> GetMoviesByFilter(MovieInput input)
        {
            List<Movies> result = null;
            try
            {

                result = _moviesProvider.get(input);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<Movies> GetMoviesListByRating(string type)
        {
            List<Movies> result = null;
            try
            {

                result = _moviesProvider.get(type);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Movies> GetMoviesListByHighestRating(string type,string name)
        {
            List<Movies> result = null;
            try
            {

                result = _moviesProvider.getHighestRating(type,name);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Movies AddRating(MoviesRequest input)
        {
            Movies result = null;
            try
            {

                result = _moviesProvider.add(input);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }


    }
}
