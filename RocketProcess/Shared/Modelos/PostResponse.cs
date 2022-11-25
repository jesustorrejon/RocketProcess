using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Modelos
{
    public class PostResponse
    {
        private PostResponse _postResponse;
        public bool Success { get; set; }
        public string Error { get; set; }

        public static PostResponse CrearRespuesta(bool xSuccess, string xError)
        {
            PostResponse postResponse = new PostResponse();
            postResponse.Success = xSuccess;
            postResponse.Error = xError;

            return postResponse;
        }
    }
}
