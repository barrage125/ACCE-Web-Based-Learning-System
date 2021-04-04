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
        public DbSet<TestGrade> TestGrade { get; set; }
        public DbSet<TestAttempt> TestAttempt { get; set; }
        public DbSet<Credential> Credential { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<CourseContent>().ToTable("CourseContent");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<UserContent>().ToTable("UserContent");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<TestGrade>().ToTable("TestGrade");
            modelBuilder.Entity<TestAttempt>().ToTable("TestAttempt");
            modelBuilder.Entity<Credential>().ToTable("Credential");
            modelBuilder.Entity<Section>().ToTable("Section");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Enrollment>()
               .HasKey(c => new { c.SectionID, c.UserID });
            modelBuilder.Entity<Course>()
               .HasKey(c => new { c.DepartmentID, c.CourseNo });
            modelBuilder.Entity<Section>()
               .HasKey(c => new { c.CourseID, c.SectionNo });
        }
    }
}