using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_6.Result
{
    public class WebApiResult
    {
        public bool IsSucceeded { get; set; } = true;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}