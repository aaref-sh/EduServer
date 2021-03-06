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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class teacher
    {
        public teacher()
        {
            this.docs = new HashSet<doc>();
            this.notifications = new HashSet<notification>();
        }

        public int Id { get; set; }
        [DisplayName("?????")]
        public string name { get; set; }
        [DisplayName("???? ??????")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
    
        public virtual ICollection<doc> docs { get; set; }
        public virtual ICollection<notification> notifications { get; set; }
    }
}
