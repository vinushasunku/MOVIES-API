using MOVIES.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using MOVIES.Entities.Common;

namespace MOVIES.DataServices.DBContext
{
    public class MoviesProvider: IMoviesProvider
    {
 
        public  List<Movies> get(MovieInput input)
        {
            try 
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", input.Title, DbType.String, ParameterDirection.Input);
                dynamicParameters.Add("@Year", input.Year, DbType.String, ParameterDirection.Input);
                dynamicParameters.Add("@GenreType", input.Genre, DbType.String, ParameterDirection.Input);
                return MoviesDbContext.GetFromStoredproc<Movies>(Constants.Movies_GetMoviesListByFilter, dynamicParameters);
            } 
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public List<Movies> get(string type)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Type", type, DbType.String, ParameterDirection.Input);
                return MoviesDbContext.GetFromStoredproc<Movies>(Constants.Movies_GetMoviesListByRating, dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Movies> getHighestRating(string type,string name)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Type", type, DbType.String, ParameterDirection.Input);
                dynamicParameters.Add("@Name", name, DbType.String, ParameterDirection.Input);
                return MoviesDbContext.GetFromStoredproc<Movies>(Constants.Movies_GetMoviesListByRating, dynamicParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Movies add(Movies input)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Title", input.Title, DbType.String, ParameterDirection.Input);
                dynamicParameters.Add("@UserID", input.UserId, DbType.String, ParameterDirection.Input);
                dynamicParameters.Add("@Rating", input.Rating, DbType.String, ParameterDirection.Input);
                return MoviesDbContext.GetFromStoredproc<Movies>(Constants.Movies_AddorUpdateMovies, dynamicParameters).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
