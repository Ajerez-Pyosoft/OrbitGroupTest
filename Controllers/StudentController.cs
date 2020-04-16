using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Student> Get()
        {
          using(var context = new sampleContext()) {
              //bring everyone
            //   return context.Student.ToList();
            // //save one
            // Student student = new Student();
            // student.Username = "martin.perez";
            // student.FirstName = "martin";
            // student.LastName = "perez";
            // student.Age = 27;
            // student.Career = "Industrial Engineer";

            // context.Student.Add(student);

            // context.SaveChanges();

            // //modify one

            // Student ModifiedStudent = context.Student.Where(student => student.FirstName == "pedro").FirstOrDefault();
            // ModifiedStudent.Age = 28;

            // context.SaveChanges();

            // //delete one
            // Student DeletedStudent = context.Student.Where(student => student.FirstName == "pedro").FirstOrDefault();
            // context.Student.Remove(DeletedStudent);

              //bring just one
              return context.Student.Where(student => student.FirstName == "pedro").ToList();
          }   
        }
    }
}
