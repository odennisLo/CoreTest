using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ApiResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
    }

    public class ApiData<T>
    {
        public bool Success { get; set; }

        public string Msg { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
