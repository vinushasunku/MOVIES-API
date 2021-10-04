using System;
using System.Collections.Generic;
using System.Text;

namespace MOVIES.Entities.Movies
{
    public class Movies
    {
        public int UserId { get; set; }
        public int MovieID { get; set; }

        public string Description { get; set; }

        public string YearReleased { get; set; }

        public int Rating { get; set; }

        public string AverageRating { get; set; }

        public string Director { get; set; }
        public string Title { get; set; }
        public string GenreType { get; set; }
    }


}
