using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACE_Web_Based_Learning_System
{
    public class Database
    {
        
        /*public Database()
        {

        }

        public List<Users> getUserList()
        {
            try
            {
                using (var db = new masterEntities2())
                {
                    return db.Users.ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Users> searchUserbyFirstName(string firstName)
        {
            try
            {
                using (var db = new masterEntities2())
                {
                    return db.Users.Where(i => i.FirstName == firstName).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Users> searchUserbyLastName(string lastName)
        {
            try
            {
                using (var db = new masterEntities2())
                {
                    return db.Users.Where(i => i.LastName == lastName).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public bool login(string email, string password)
        {
            using (var db = new masterEntities2())
            {
                var user = db.Users.Where(i => i.Email == email).ToList();
                if (user.Count == 0)
                {
                    return false;
                }
                if (user[0].Password != password)
                {
                    return false;
                }
                return true;

                
            }
        }
        public bool addUserToDatabase(Users user, UserContent userContent)
        {
            try
            {
                using (var db = new masterEntities2())
                {
                    var newUser = user;
                    var newUserContent = userContent;
                    
                    db.UserContent.Add(newUserContent);
                    
                    db.SaveChanges();
                    user.UserContent = newUserContent.UserID;
                    
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool addCourseToDatabase(Courses course, CourseContent courseContent)
        {
            try
            {
                using (var db = new masterEntities2())
                {
                    var newUser = course;
                    var newUserContent = courseContent;
                    course.CourseContent = courseContent.CourseID;
                    db.CourseContent.Add(newUserContent);
                    db.Courses.Add(course);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }*/


    }
}