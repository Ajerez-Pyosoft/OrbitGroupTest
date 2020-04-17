using System;

namespace api.Results
{
    public class ApiResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }


        public ApiResult()
        {
        }
    }
}