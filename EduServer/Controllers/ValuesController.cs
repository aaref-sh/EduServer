using EduServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EduServer.Controllers
{
    public class ValuesController : ApiController
    {
        serdbEntities1 db = new serdbEntities1();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        [HttpGet]
        public List<lecture> DaysTable(int student_id)
        {
            student s = (from x in db.students where x.Id == student_id select x).First();
            return (from x in db.lectures where x.clas == s.clas && x.year == s.year select x).ToList();
        } 
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
