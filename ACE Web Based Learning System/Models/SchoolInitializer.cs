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
            /*var users = new List<User>
            {
            new User{LastName="Alexander",FirstName="Carson"},
            new User{LastName="Alonso",FirstName="Meredith"},
            new User{LastName="Anand",FirstName="Arturo"},
            new User{LastName="Barzdukas",FirstName="Gytis"},
            new User{LastName="Li",FirstName="Yan"},
            new User{LastName="Justice",FirstName="Peggy"},
            new User{LastName="Norman",FirstName="Laura"},
            new User{LastName="Olivetto",FirstName="Nino"}
            };
            
            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();
            */
            /*
            var credentials = new List<Credential>
            {
            new Credential{ID="user1",Password="password", UserID=users[0].ID, User=User[0]},
            new Credential{ID="user2",Password="password", UserID=users[1].ID, User=User[1]},
            new Credential{ID="user3",Password="password", UserID=users[2].ID, User=User[2]},
            new Credential{ID="user4",Password="password", UserID=users[3].ID, User=User[3]},
            new Credential{ID="user5",Password="password", UserID=users[4].ID, User=User[4]},
            new Credential{ID="user6",Password="password", UserID=users[5].ID, User=User[5]},
            new Credential{ID="user7",Password="password", UserID=users[6].ID, User=User[6]},
            new Credential{ID="user8",Password="password", UserID=users[7].ID, User=User[7]}
            };

            credentials.ForEach(s => context.Credential.Add(s));
            context.SaveChanges();
            */
            /*
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
            context.SaveChanges();*/
        }
    }
}