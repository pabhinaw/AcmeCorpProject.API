using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Results
{
    public interface IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
