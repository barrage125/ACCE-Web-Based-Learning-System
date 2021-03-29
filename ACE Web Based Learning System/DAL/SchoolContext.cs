using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACE_Web_Based_Learning_System.Models;

namespace ACE_Web_Based_Learning_System.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<CourseContent> CourseContent { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<UserContent> UserContent { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}