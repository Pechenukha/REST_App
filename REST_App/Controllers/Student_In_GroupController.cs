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
    public class Student_In_GroupController : ControllerBase
    {
        CollegeContext db;

        public Student_In_GroupController(CollegeContext context)
        {
            db = context;
            if (!db.student_in_group.Any())
            {
                db.student_in_group.Add(new StudentInGroup { id = 1, id_student = 1, id_group = 2 });
                db.student_in_group.Add(new StudentInGroup { id = 2, id_student = 2, id_group = 1 });
                db.SaveChanges();
            }
        }

        // GET: api/student_in_group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInGroup>>> Get()
        {
            return await db.student_in_group.ToListAsync();
        }

        // POST api/student_in_group
        [HttpPost]
        public async Task<ActionResult<StudentInGroup>> Post(StudentInGroup gr)
        {
            if (gr == null)
            {
                return BadRequest();
            }

            db.student_in_group.Add(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }

        // PUT api/student_in_group
        [HttpPut]
        public async Task<ActionResult<StudentInGroup>> Put(StudentInGroup gr)
        {
            if (gr == null)
            {
                return BadRequest();
            }
            if (!db.student_in_group.Any(x => x.id == gr.id))
            {
                return NotFound();
            }

            db.Update(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }

        // Delete api/student_in_group/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentInGroup>> Delete(int id)
        {
            StudentInGroup gr = db.student_in_group.FirstOrDefault(x => x.id == id);
            if (gr == null)
            {
                return NotFound();
            }
            db.student_in_group.Remove(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }
    }
}
