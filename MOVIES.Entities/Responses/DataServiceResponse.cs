using System;
using System.Collections.Generic;
using System.Text;

namespace MOVIES.Entities.Responses
{
    public class DataServiceResponse
    {
        public bool RequestSucceeded { get; set; }

        public string Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }
        public string ExceptionMessages { get; set; }

    }
}
