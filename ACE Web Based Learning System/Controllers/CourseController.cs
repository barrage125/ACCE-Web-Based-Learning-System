﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACE_Web_Based_Learning_System.DAL;
using ACE_Web_Based_Learning_System.Models;
using Newtonsoft.Json;

namespace ACE_Web_Based_Learning_System.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Courses
        //public ActionResult Index()
        //{
        //    return View(db.Course.ToList());
        //}

        public ActionResult CourseView(String courseNumber)
        {
            //really bad code
            //singleordefault will only grab if there is a single element in the databsae
            //if more than one or zero is found, then it will throw an exception
            //using statement automatically disposes after use
            using (SchoolContext dbContext = new SchoolContext())
            {
                var course = db.Course.SingleOrDefault(i => i.CourseNo == courseNumber);
                var user = Session["User"] as ACE_Web_Based_Learning_System.Models.User;

                Section enrolledSection = null;

                //go through ALL of the course sections and find the section teh user is enrolled in
                //not the best way but all other ways cause disposing issues that were not resolved
                //this works but is not the best way for abstraction/encapsulation purposes
                //best way is to pass in enrollmentID as the parameter so we know the enrollement already. this way causes issues with presenting the user courses in the nav bar
                //and no workaround has been found

                foreach (var section in course.Sections)
                {
                    //!!!! IMPORTANT !!!!
                    //USERS SHOULD ONLY BE ENROLLED IN ONE COURSE
                    //IF NOT, THIS CODE WILL FAIL all the time
                    

                    var enrolledSections = section.enrollments.Where(i => i.UserID == user.ID).ToList();
                    //if enrollement found, then section is enrolled section
                    if (enrolledSections.Count > 0)
                    {
                        enrolledSection = section as Section;
                    }

                }


                var testList = course.Tests.ToList();
                //test list
                //finds attempts for ANY tests
               
                var attemptedTests = new List<TestAttempt>();
                var userTestsTaken = dbContext.TestAttempt.Where(i => i.UserID == user.ID).ToList();
                foreach (var exam in testList)
                {
                    //finds tests attempts for this specific exam 
                    //could be done other way (find tests attempts for specific exam and then user taken)
                    //done this way because it is presumed to be more efficient (instead of having all the test attempts for a certain test loaded up at once)
                    var userAttemptsonExam = userTestsTaken.Where(i => i.TestID == exam.ID).ToList();
                    if (userAttemptsonExam.Count > 0)
                    {
                        attemptedTests.Add(userAttemptsonExam[0]);
                    }

                }

                var testListDeserialized = new List<TestQuestions>();

                foreach (var test in testList)
                {
                    //test questions in JSON format, has to deserialize
                    var tempTest = JsonConvert.DeserializeObject<TestQuestions>(test.QUESTIONS);
                    testListDeserialized.Add(tempTest);
                }

                ViewData["Section"] = enrolledSection;
               
                ViewData["CourseContent"] = enrolledSection.Course.CourseContents.ToList() as List<ACE_Web_Based_Learning_System.Models.CourseContent>;
                ViewData["Tests"] = testListDeserialized;
                ViewData["TestsAttempts"] = attemptedTests;
                return View(user);
            }
        }
        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course courses = db.Course.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseName,CourseContent")] Course courses)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course courses = db.Course.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseName,CourseContent")] Course courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course courses = db.Course.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course courses = db.Course.Find(id);
            db.Course.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult TestView(String courseNumber, int testNo)
        {
            var user = Session["User"] as ACE_Web_Based_Learning_System.Models.User;
            var course = db.Course.Where(i => i.CourseNo == courseNumber).ToList();
            var testList = course[0].Tests.ToList();
            

           
            var testToReturn = JsonConvert.DeserializeObject<TestQuestions>(testList[testNo].QUESTIONS);
           
            ViewData["Test"] = testToReturn;

            return View(user);
        }
        [HttpPost]
        public ActionResult CheckAnswer(String courseNumber, int testNo,String answers)
        {
            var user = Session["User"] as ACE_Web_Based_Learning_System.Models.User;
            var course = db.Course.Where(i => i.CourseNo == courseNumber).ToList();
            var testList = course[0].Tests.ToList();
            var correctAnswers = new List<int>();

            var userAnswers = answers.Split(',');
            var testToReturn = JsonConvert.DeserializeObject<TestQuestions>(testList[testNo].QUESTIONS);
            for(int i = 0; i < testToReturn.questions.Count; i++)
            {
                var j = 0;
               foreach (var answer in testToReturn.questions[i].answers)
                {
                    
                    if (answer.isAnswer)
                    {
                        correctAnswers.Add(j);
                        break;
                    }
                    j++;
                }
            }
            var correctNumAnswers = 0;
            for(int k = 0; k < correctAnswers.Count; k++)
            {
                if (correctAnswers[k].ToString() == userAnswers[k])
                {
                    correctNumAnswers++;
                }
            }
            
            var score = correctNumAnswers.ToString() + "/" + correctAnswers.Count.ToString();
         var attempt = new TestAttempt();
        attempt.ANSWERS = score.ToString();
        
        attempt.UserID = user.ID;
        attempt.TestID = testList[testNo].ID;
       
        
          db.TestAttempt.Add(attempt);
            db.SaveChanges();

            var loginresult = new JsonResult { Message = "bad" };
            return Json(loginresult);
        }
    }
}
public class TestQuestions
{
    
    public IList<Question> questions { get; set; }

}
public class Question
{
    public String question { get; set; }
    public IList<Answer> answers { get; set; }
   
}
public class Answer
{
    public bool isAnswer { get; set; }
    public String answer { get; set; }

}