using MOVIES.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOVIES.DataServices.DBContext
{
    public interface IMoviesProvider
    {
        List<Movies> get(MovieInput input);
        List<Movies> get(string type);

        List<Movies> getHighestRating(string type,string name);

        Movies add(Movies input);
    }
}
