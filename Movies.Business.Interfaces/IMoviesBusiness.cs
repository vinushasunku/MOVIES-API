using MOVIES.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOVIES.Business.Interfaces
{
    public interface IMoviesBusiness
    {
        List<Movies> GetMoviesByFilter(MovieInput input);
        List<Movies> GetMoviesListByRating(string type);
        List<Movies> GetMoviesListByHighestRating(string type, string name);

        Movies AddRating(MoviesRequest input);
    }
}
