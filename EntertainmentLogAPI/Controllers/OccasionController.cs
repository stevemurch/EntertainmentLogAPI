using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntertainmentLogAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentLogAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/occasion")]
    public class OccasionController : Controller
    {
        // GET: api/occasion
        [HttpGet]
        public IEnumerable<Occasion> Get()
        {
            return Occasion.GetAllFromDb();
        }

        // GET: api/occasion/5
        [HttpGet("{id}", Name = "Get")]
        public Occasion Get(string id)
        {
            var theOccasion = Occasion.GetById(id);
            return theOccasion;
        }
        
        // POST: api/occasion
        [HttpPost]
        public Occasion Post([FromBody]Occasion value)
        {
            var result = Occasion.AddOccasion(value);
            return result;
        }

        [HttpOptions]
        public void Options()
        { }
        
        // PUT: api/occasion/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Occasion value)
        {
        }
        
        // DELETE: api/occasion/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Occasion.DeleteById(id);
        }
    }
}
