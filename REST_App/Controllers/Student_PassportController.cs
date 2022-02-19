using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_App.Models;
using Microsoft.EntityFrameworkCore;

namespace REST_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_PassportController : ControllerBase
    {
        CollegeContext db;

        public Student_PassportController(CollegeContext context)
        {
            db = context;
            if (!db.student_passport.Any())
            {
                db.student_passport.Add(new StudentPassport { id = 1, student_id = 1, number = "34 43", series = "435234"});
                db.student_passport.Add(new StudentPassport { id = 2, student_id = 2, number = "56 34", series = "128456" });
                db.SaveChanges();
            }
        }

        // GET: api/student_passport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPassport>>> Get()
        {
            return await db.student_passport.ToListAsync();
        }

        // POST api/student_passport
        [HttpPost]
        public async Task<ActionResult<StudentPassport>> Post(StudentPassport pas)
        {
            if (pas == null)
            {
                return BadRequest();
            }

            db.student_passport.Add(pas);
            await db.SaveChangesAsync();
            return Ok(pas);
        }

        // PUT api/student_passport
        [HttpPut]
        public async Task<ActionResult<StudentPassport>> Put(StudentPassport pas)
        {
            if (pas == null)
            {
                return BadRequest();
            }
            if (!db.student_passport.Any(x => x.id == pas.id))
            {
                return NotFound();
            }

            db.Update(pas);
            await db.SaveChangesAsync();
            return Ok(pas);
        }

        // Delete api/student_passport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentPassport>> Delete(int id)
        {
            StudentPassport pas = db.student_passport.FirstOrDefault(x => x.id == id);
            if (pas == null)
            {
                return NotFound();
            }
            db.student_passport.Remove(pas);
            await db.SaveChangesAsync();
            return Ok(pas);
        }
    }
}
