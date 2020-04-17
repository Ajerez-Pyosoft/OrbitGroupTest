using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Results;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly sampleContext dbContext;

        public StudentController(sampleContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get() {
            return Ok(new ApiResult {
                Data = dbContext.Student.ToList(),
                Message = "Student information"
                }
            );
        }

        // GET: api/Student/5
        [HttpGet]      
        [Route("{id}")]      
        public ActionResult<IEnumerable<Student>> GetStudent(int id)
        {

                var data = dbContext.Student
                            .Where(student => student.Id == id)
                            .FirstOrDefault();

                if (data == null) {
                    return NotFound();
                }

                return Ok(data);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid) {
                result.Message = "Invalid Student Information";
                result.IsError = true;
                return BadRequest(result);
            }
                

            dbContext.Student.Add(student);
            dbContext.SaveChanges();
            result.Message = "Student registered successfully";
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Student student)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid) {
                result.Message = "Invalid Student Information";
                result.IsError = true;
                return BadRequest(result);
            }

            var dbStudent = dbContext.Student
                .Where(S => S.Id == student.Id)
                .FirstOrDefault();

            if (dbStudent == null) {
                result.Message = $"Student with id {student.Id} not found";
                result.IsError = true;
                return BadRequest(result);
            }
                
            dbStudent.Username = student.Username; 
            dbStudent.FirstName = student.FirstName; 
            dbStudent.LastName = student.LastName; 
            dbStudent.Age = student.Age; 
            dbStudent.Career = student.Career; 

            dbContext.Update(dbStudent);
            dbContext.SaveChanges();

            result.Message = "Student modified successfully";
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var result = new ApiResult();
            if (!ModelState.IsValid) {
                result.Message = "Invalid Student Information";
                result.IsError = true;
                return BadRequest(result);
            }

            var dbStudent = dbContext.Student
                .Where(s => s.Id == id)
                .FirstOrDefault();

            if (dbStudent == null) {
                result.Message = $"Student with id {id} not found";
                result.IsError = true;
                return BadRequest(result);
            }

            dbContext.Remove(dbStudent);
            dbContext.SaveChanges();

            result.Message = "Student deleted successfully";
            return Ok(result);
        
        }
    }
}
