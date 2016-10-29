using FetchNStore.DAL;
using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FetchNStore.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository repo = new ResponseRepository();
        // GET api/<controller>
        public IEnumerable<dynamic> Get()
        {
            List<Response> responses = repo.GetResponses();
            return responses;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]dynamic value)
        {
            repo.AddResponse(new Response
            {
                StatusCode = value.statusCode,
                Url = value.url,
                Method = value.method,
                ResponseTime = value.time
            });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}