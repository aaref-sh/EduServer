using EduServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

namespace EduServer.Controllers
{
    public class ValuesController : ApiController
    {
        serdbEntities2 db = new serdbEntities2();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public string upload()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                       HttpContext.Current.Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/docs"),fileName);
                file.SaveAs(path);
            }
            return file != null ? file.FileName + " OK" : null; 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        [HttpGet]
        public List<lecture> DaysTable(int id)
        {
            student s = (from x in db.students where x.Id == id select x).First();
            return (from x in db.lectures where x.clas == s.clas && x.year == s.year && x.specialization_id == s.specialization_id select x).ToList();
        } 
        [HttpGet]
        public List<notification> notificationlist()
        {
            return (from x in db.notifications select x).ToList();
        } 
        [HttpPost]
        public bool signin(student s){
            List<student> sl = (from x in db.students where x.Id == s.Id && s.password == x.password select x).ToList();
            if(sl.Count==0)return false;
            return true;
        }
        [HttpPost]
        public int teachersignin(teacher t)
        {
            List<teacher> tl = (from x in db.teachers where x.name == t.name && t.password == x.password select x).ToList();
            if(tl.Count==0)return 0;
            return tl.First().Id;
        }
        
        [HttpGet]
        public void delete(int id)
        {
            db.notifications.Remove((from x in db.notifications where x.Id == id select x).First());
            db.SaveChanges();
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
