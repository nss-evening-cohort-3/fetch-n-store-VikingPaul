using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class ResponseRepository
    {
        public ResponseRepository()
        {
            Context = new ResponseContext();
        }

        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }

        public ResponseContext Context { get; set; }

        public void AddResponse(Response newInput)
        {
            Context.Responses.Add(newInput);
            Context.SaveChanges();
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList<Response>();
        }
    }
}