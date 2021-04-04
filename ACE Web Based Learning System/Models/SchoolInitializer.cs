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
            var users = new List<User>
            {
            new User{ID=1,Email="user@test.com",LastName="Alexander",Password="password",FirstName="Carson",UserRole="Student",UserContent=0,},
            new User{ID=2,Email="user@test.com",LastName="Alonso",Password="password",FirstName="Meredith",UserRole="Student",UserContent=0,},
            new User{ID=3,Email="user@test.com",LastName="Anand",Password="password",FirstName="Arturo",UserRole="Student",UserContent=0,},
            new User{ID=4,Email="user@test.com",LastName="Barzdukas",Password="password",FirstName="Gytis",UserRole="Student",UserContent=0,},
            new User{ID=5,Email="user@test.com",LastName="Li",Password="password",FirstName="Yan",UserRole="Student",UserContent=0,},
            new User{ID=6,Email="user@test.com",LastName="Justice",Password="password",FirstName="Peggy",UserRole="Student",UserContent=0,},
            new User{ID=7,Email="user@test.com",LastName="Norman",Password="password",FirstName="Laura",UserRole="Student",UserContent=0,},
            new User{ID=8,Email="user@test.com",LastName="Olivetto",Password="password",FirstName="Nino",UserRole="Student",UserContent=0,}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{ID=1050,CourseName="Chemistry",CourseContent=0,},
            new Course{ID=4022,CourseName="Microeconomics",CourseContent=0,},
            new Course{ID=4041,CourseName="Macroeconomics",CourseContent=0,},
            new Course{ID=1045,CourseName="Calculus",CourseContent=0,},
            new Course{ID=3141,CourseName="Trigonometry",CourseContent=0,},
            new Course{ID=2021,CourseName="Composition",CourseContent=0,},
            new Course{ID=2042,CourseName="Literature",CourseContent=0,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
        }
    }
}