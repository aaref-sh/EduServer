﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class serdbEntities2 : DbContext
    {
        public serdbEntities2()
            : base("name=serdbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<lecture> lectures { get; set; }
        public DbSet<lecture_at> lecture_at { get; set; }
        public DbSet<specialization> specializations { get; set; }
        public DbSet<student> students { get; set; }
        public DbSet<teacher> teachers { get; set; }
        public DbSet<dayinweek> dayinweeks { get; set; }
        public DbSet<notification> notifications { get; set; }
        public DbSet<doc> docs { get; set; }
    }
}
