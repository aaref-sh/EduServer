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
    
    public partial class lecture_at
    {
        public lecture_at()
        {
            this.lectures = new HashSet<lecture>();
        }
    
        public int Id { get; set; }
        public string time_at { get; set; }
    
        public virtual ICollection<lecture> lectures { get; set; }
    }
}