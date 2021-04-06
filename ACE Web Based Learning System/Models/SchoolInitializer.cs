using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ACE_Web_Based_Learning_System.DAL;

namespace ACE_Web_Based_Learning_System.Models
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext> //Change IfModelChanges to Always to force db rebuild
    {
        protected override void Seed(SchoolContext context)
        {
            var credential = new Credential { Password = "password", ID = "HEYOP" };
            var users = new List<User>
            {
            
            new User{ID=1,Credential= credential,LastName="Alexander",FirstName="Carson",UserContent=new UserContent{Email = "user@test.com"} },
         
            new User{ID=2,Credential= credential,LastName="Mr",FirstName="Worldwide",UserContent=new UserContent{Email = "user@test.com"} },
            new User{ID=3,Credential= credential,LastName="Test",FirstName="User",UserContent=new UserContent{Email = "user@test.com"} },
            new User{ID=4,Credential= credential,LastName="Big",FirstName="Eric",UserContent=new UserContent{Email = "user@test.com"} },
            new User{ID=5,Credential= credential,LastName="Big",FirstName="Alex",UserContent=new UserContent{Email = "user@test.com"} },
            new User{ID=6,Credential= credential,LastName="Big",FirstName="Cassidy",UserContent=new UserContent{Email = "user@test.com"} },
         
            };
         

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseNo="1050",CourseName="Chemistry"},
            new Course{CourseNo="4022",CourseName="Microeconomics"},
            new Course{CourseNo="4041",CourseName="Macroeconomics"},
            new Course{CourseNo="1045",CourseName="Calculus"},
            new Course{CourseNo="3141",CourseName="Trigonometry"},
            new Course{CourseNo="2021",CourseName="Composition"},
            new Course{CourseNo="2042",CourseName="Literature"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
        }
    }
}