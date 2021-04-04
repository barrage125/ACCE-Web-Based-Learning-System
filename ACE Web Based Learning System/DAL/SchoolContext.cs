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
        public SchoolContext() : base("name=SchoolContext")
        {
        }
        public DbSet<CourseContent> CourseContent { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserContent> UserContent { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestGrade> TEST_GRADE { get; set; }
        public DbSet<TestAttempt> TEST_ATTEMPT { get; set; }
        public DbSet<WebID> WEB_ID { get; set; }
        public DbSet<Section> SECTION { get; set; }
        public DbSet<Enrollment> ENROLLMENT { get; set; }
        public DbSet<Test> TEST { get; set; }
        public DbSet<Department> DEPARTMENT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<CourseContent>().ToTable("CourseContent");
            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<UserContent>().ToTable("UserContent");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<TestGrade>().ToTable("TEST_GRADE");
            modelBuilder.Entity<TestAttempt>().ToTable("TEST_ATTEMPT");
            modelBuilder.Entity<WebID>().ToTable("<WEB_ID");
            modelBuilder.Entity<Section>().ToTable("SECTION");
            modelBuilder.Entity<Enrollment>().ToTable("ENROLLMENT");
            modelBuilder.Entity<Test>().ToTable("TEST");
            modelBuilder.Entity<Department>().ToTable("DEPARTMENT");
            modelBuilder.Entity<Enrollment>()
               .HasKey(c => new { c.SECTION_ID, c.USER_ID });
        }
    }
}