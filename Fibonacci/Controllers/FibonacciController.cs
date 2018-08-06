using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace Fibonacci.Controllers
{
    [Route("api/[FibonacciController]")]
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci/5
        [Route("api/FibonacciController/{id}")]
        [HttpGet] 
        public HttpResponseMessage Get(int id)
        {
            List<int> numberOfSequences = new List<int>();

            // Check for negative numbers
            if (id <= 0)
            {
                HttpError error = new HttpError("Input cannot be negative or zero");
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }
            else
            { 
                int a = 0, b = 1, c = 0;

                numberOfSequences.Add(a);
                numberOfSequences.Add(b);

                for (int i = 2; i < id; i++)
                {
                    c = a + b;
                    numberOfSequences.Add(c);
                    a = b;
                    b = c;
                }
                return Request.CreateResponse(HttpStatusCode.OK, numberOfSequences);
            }
        }
    }
}
