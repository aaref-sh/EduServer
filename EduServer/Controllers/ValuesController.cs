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
        [HttpGet]
        public List<Doc> GetDocList(int id)
        {
            List<doc> dl;
            List<Doc> Dl = new List<Doc>();
            if (id == 0) dl = db.docs.ToList();
            else dl = (from x in db.docs where id == x.owner select x).ToList();
            foreach (var x in dl)
            {
                Doc d = new Doc();
                d.id = x.id;
                d.name = x.path;
                d.ownerid = x.owner;
                d.owner = x.teacher.name;
                Dl.Add(d);
            }
            return Dl;
        }
        [HttpPost]
        public String addnotification(notification n)
        {
            db.notifications.Add(n);
            db.SaveChanges();
            return "done";
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
        [HttpPost]
        public void addrequest(request r,string s)
        {
            r.request_type = (from x in db.request_type where x.name == s select x).First().id;
            db.requests.Add(r);
            db.SaveChanges();
        }

        [HttpGet]
        public List<Lec> DaysTable(int id)
        {
            List<Lec> ll = new List<Lec>();
            student s = (from x in db.students where x.Id == id select x).First();
            var l = (from x in db.lectures where x.clas == s.clas && x.year == s.year && x.specialization_id == s.specialization_id select x).ToList();
            foreach (var x in l)
            {
                Lec lc = new Lec();
                lc.time = x.lecture_at_id;
                lc.day = x.dayinweek;
                lc.material = x.material.material_name;
                lc.hall = x.hall.name;
                ll.Add(lc);
            }
            return ll;
        } 
        [HttpGet]
        public List<Notif> notificationlist()
        {
            var l = db.notifications.ToList();
            List<Notif> nl = new List<Notif>();
            foreach (var x in l)
            {
                Notif n = new Notif();
                n.id = x.Id;
                n.author = x.teacher.name;
                n.title = x.title;
                n.description = x.description;
                n.authorid = x.author;
                nl.Add(n);
            }
            return nl;
        } 
        [HttpPost]
        public List<Req> requestlist(student s)
        {
            List<Req> rl = new List<Req>();
            var l = (from x in db.requests where x.requester == s.Id select x).ToList();
            foreach (var x in l)
            {
                Req r = new Req();
                r.id = x.id;
                r.status = x.status1.status1;
                r.statusid = x.status;
                r.type = x.request_type1.name;
                r.typeid = x.request_type;
                rl.Add(r);
            }
            return rl;
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
        public List<Mrk> marklist(student s)
        {
            var l = (from x in db.marks where x.student_id == s.Id select x).ToList();
            List<Mrk> ml = new List<Mrk>();
            foreach (var x in l)
            {
                Mrk m = new Mrk();
                m.mark = x.mark1;
                m.name = x.material.material_name;
                ml.Add(m);
            }
            return ml;
        }
        [HttpPost]
        public void del(notification N)
        {
            notification n = (from x in db.notifications where x.Id == N.Id select x).First();
            db.notifications.Remove(n);
            db.SaveChanges();
        }

    }
}
