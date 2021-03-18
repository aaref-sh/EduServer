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
        [HttpGet]
        public List<doc> GetDocList(int? id)
        {
            List<doc> dl ;
            if (id != null) dl = (from x in db.docs where id == x.owner select x).ToList();
            else dl = db.docs.ToList();
            return dl;
        }
        [HttpGet]
        public string getpath()
        {
            return HttpContext.Current.Server.MapPath("~/docs/");
        }
        [HttpGet]
        public void deletedoc(int id)
        {
            doc d = (from x in db.docs where x.id == id select x).First();
            var path = d.path;
            FileInfo file = new FileInfo(path);
            file.Delete();
            db.docs.Remove(d);
            db.SaveChanges();
        }
        [HttpPost]
        public string upload(int id)
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                       HttpContext.Current.Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/docs"),fileName);
                file.SaveAs(path);
                doc d = new doc();
                d.owner = id;
                d.path = path;
                db.docs.Add(d);
                db.SaveChanges();
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
            return db.notifications.ToList();
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
        
        [HttpPost]
        public void del(notification N)
        {
            notification n = (from x in db.notifications where x.Id == N.Id select x).First();
            db.notifications.Remove(n);
            db.SaveChanges();
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
