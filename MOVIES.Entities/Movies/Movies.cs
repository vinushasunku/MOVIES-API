using System;
using System.Collections.Generic;
using System.Text;

namespace MOVIES.Entities.Movies
{
    public class Movies
    {
        public int MovieID { get; set; }

        public string YearReleased { get; set; }

        public float Rating { get; set; }
        public string Title { get; set; }
        public string GenreType { get; set; }
    }

    public class MoviesRequest
    {
        public int UserId { get; set; }
        public float Rating { get; set; }

        public string Title { get; set; }
    }

}
