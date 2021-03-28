using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduServer.Models
{
    public class Lec
    {
        public int time{set;get;}
        public int day { set; get; }
        public string hall { set; get; }
        public string material { set; get; }
    }
    public class Req
    {
        public int id { set; get; }
        public int typeid { set; get; }
        public int statusid { set; get; }
        public string type { set; get; }
        public string status { set; get; }
    }
    public class Notif
    {
        public int id { set; get; }
        public int authorid { set; get; }
        public string description { set; get; }
        public string title { set; get; }
        public string author { set; get; }
    }
    public class Doc
    {
        public int id { set; get; }
        public int ownerid { set; get; }
        public string owner { set; get; }
        public string name { set; get; }
    }
    public class Mrk
    {
        public string name { set; get; }
        public double? mark { set; get; }
    }
}