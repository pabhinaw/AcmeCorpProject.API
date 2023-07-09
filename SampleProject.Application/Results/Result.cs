using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Results
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
