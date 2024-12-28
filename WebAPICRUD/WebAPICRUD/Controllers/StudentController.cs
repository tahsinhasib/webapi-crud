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
        [HttpGet]
        [Route("api/student/all")]
        public HttpResponseMessage GetAll()
        {
            var students = new List<Student>();
            for (int i = 1; i <= 10; i++)
            {
                students.Add(new Student()
                {
                    StudentID = i,
                    StudentName = "S" + i
                }); ;
            }
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            //
            //
            return Request.CreateResponse(HttpStatusCode.OK, new Student() { StudentID = id });
        }
        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage Create(Student s)
        {
            //
            //
            s.StudentID = 10;
            s.StudentName = "Tahsin";
            return Request.CreateResponse(HttpStatusCode.OK, s);
        }
    }
}
