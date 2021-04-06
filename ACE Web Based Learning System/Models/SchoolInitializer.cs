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
           

            var credentials = new List<Credential>
            {
            new Credential{ID="user1",Password="password", UserID=users[0].ID, User=users[0]},
            new Credential{ID="user2",Password="password", UserID=users[1].ID, User=users[1]},
            new Credential{ID="user3",Password="password", UserID=users[2].ID, User=users[2]},
            new Credential{ID="user4",Password="password", UserID=users[3].ID, User=users[3]},
            new Credential{ID="user5",Password="password", UserID=users[4].ID, User=users[4]},
            new Credential{ID="user6",Password="password", UserID=users[5].ID, User=users[5]},
            new Credential{ID="user7",Password="password", UserID=users[6].ID, User=users[6]},
            new Credential{ID="user8",Password="password", UserID=users[7].ID, User=users[7]}
            };

            credentials.ForEach(s => context.Credential.Add(s));
          

            var userContent = new List<UserContent>
            {
            new UserContent{ID="user1",Email="Alexander@gmail.com", UserID=users[0].ID, User=users[0]},
            new UserContent{ID="user2",Email="Alexander@gmail.com", UserID=users[1].ID, User=users[1]},
           new UserContent{ID="user3",Email="Alexander@gmail.com", UserID=users[2].ID, User=users[2]},
            new UserContent{ID="user4",Email="Alexander@gmail.com", UserID=users[3].ID, User=users[3]},
            new UserContent{ID="user5",Email="Alexander@gmail.com", UserID=users[4].ID, User=users[4]},
            new UserContent{ID="user6",Email="Alexander@gmail.com", UserID=users[5].ID, User=users[5]},
            new UserContent{ID="user7",Email="Alexander@gmail.com", UserID=users[6].ID, User=users[6]},
           new UserContent{ID="user8",Email="Alexander@gmail.com", UserID=users[7].ID, User=users[7]},
            };
            userContent.ForEach(s => context.UserContent.Add(s));

            var department = new List<Department>
            {
                new Department{ID="TestDepartment"}
            };
            department.ForEach(s => context.Department.Add(s));
            




            var courses = new List<Course>
            {
            new Course{CourseNo="1050",CourseName="Chemistry", Department = department[0], DepartmentID=department[0].ID},
            new Course{CourseNo="4022",CourseName="Microeconomics", Department = department[0],DepartmentID=department[0].ID},
            new Course{CourseNo="4041",CourseName="Macroeconomics",Department = department[0],DepartmentID=department[0].ID},
            new Course{CourseNo="1045",CourseName="Calculus",Department = department[0],DepartmentID=department[0].ID},
            new Course{CourseNo="3141",CourseName="Trigonometry",Department = department[0],DepartmentID=department[0].ID},
            new Course{CourseNo="2021",CourseName="Composition",Department = department[0],DepartmentID=department[0].ID},
            new Course{CourseNo="2042",CourseName="Literature",Department = department[0],DepartmentID=department[0].ID}
            };
            courses.ForEach(s => context.Course.Add(s));


            var courseContent = new List<CourseContent>
            {
            new CourseContent{Content="1050", Course=courses[0], CourseID= courses[0].ID},
            new CourseContent{Content="1050", Course=courses[1], CourseID= courses[1].ID},
            new CourseContent{Content="1050", Course=courses[2], CourseID= courses[2].ID},
            new CourseContent{Content="1050", Course=courses[3], CourseID= courses[3].ID},
            new CourseContent{Content="1050", Course=courses[4], CourseID= courses[4].ID},
            new CourseContent{Content="1050", Course=courses[5], CourseID= courses[5].ID},
            new CourseContent{Content="1050", Course=courses[6], CourseID= courses[6].ID},

            };
            courseContent.ForEach(s => context.CourseContent.Add(s));

            var section = new List<Section>
            {
            new Section{SectionNo=11, Course=courses[0], CourseID= courses[0].ID, Capacity =20},
            new Section{SectionNo=22, Course=courses[1], CourseID= courses[1].ID, Capacity =20},
            new Section{SectionNo=33, Course=courses[2], CourseID= courses[2].ID, Capacity =20},
            new Section{SectionNo=44, Course=courses[3], CourseID= courses[3].ID, Capacity =20},
            new Section{SectionNo=55, Course=courses[4], CourseID= courses[4].ID, Capacity =20},
            new Section{SectionNo=66, Course=courses[5], CourseID= courses[5].ID, Capacity =20},
            new Section{SectionNo=77, Course=courses[6], CourseID= courses[6].ID, Capacity =20},

            };
            section.ForEach(s => context.Section.Add(s));


            var enrollments = new List<Enrollment>
            {
            new Enrollment{Type="Test",User=users[0], Section=section[0], UserID=users[0].ID, SectionID=section[0].ID},
            

            };
            enrollments.ForEach(s => context.Enrollment.Add(s));

            context.SaveChanges();

        }
    }
}