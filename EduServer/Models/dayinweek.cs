//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EduServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class dayinweek
    {
        public dayinweek()
        {
            this.lectures = new HashSet<lecture>();
        }
    
        public int id { get; set; }
        public string dayname { get; set; }
    
        public virtual ICollection<lecture> lectures { get; set; }
    }
}