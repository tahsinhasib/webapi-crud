using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICRUD.EF.Tables;

namespace WebAPICRUD.Controllers
{
    public class StudentController : ApiController
    {
        StudentContext db = new StudentContext();

        private static List<Student> students = new List<Student>();

        // GET api/student/all get all students from the list
        [HttpGet]
        [Route("api/student/all")]
        public HttpResponseMessage GetAll()
        {
            var students = db.Students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        // GET api/student/5 search by StudentID
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        // POST api/student/create create a new student
        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage Create(Student s)
        {
            s.StudentName = "Tahsin";
            db.Students.Add(s);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, s);
        }

        [HttpPut]
        [Route("api/student/update/{id}")]
        public HttpResponseMessage Update(int id, Student s)
        {
            if (s == null || s.StudentID != id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid data");
            }

            var student = students.FirstOrDefault(st => st.StudentID == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }

            student.StudentName = s.StudentName;
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [HttpDelete]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }

            students.Remove(student);
            return Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
        }
    }
}