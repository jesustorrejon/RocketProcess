using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared
{
    public class Response<T>
    {
        public T Result { get; set; }

        public Response(T result)
        {
            Result = result;
        }
    }
}
