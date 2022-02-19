using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using REST_App.Models;
using System.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using Microsoft.Extensions.Configuration;



namespace REST_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        CollegeContext db;
  
        public FacultiesController(CollegeContext context)
        {
            db = context;
            if (!db.faculty.Any())
            {
                db.faculty.Add(new Faculty { id = 1, name_of_faculty = "Techical", head_of_faculty = "Mr. Root"});
                db.faculty.Add(new Faculty { id = 2, name_of_faculty = "Art", head_of_faculty = "Mrs. Wolf"});
                db.SaveChanges();
            }
        }


        // GET: api/faculties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> Get()
        {
            return await db.faculty.ToListAsync();
        } 

        // POST api/faculties
        [HttpPost]
        public async Task<ActionResult<Faculty>> Post(Faculty fac)
        {
            if (fac == null)
            {
                return BadRequest();
            }

            db.faculty.Add(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }
 
        // PUT api/students
        [HttpPut]
        public async Task<ActionResult<Faculty>> Put(Faculty fac)
        {
            if (fac == null)
            {
                return BadRequest();
            }
            if (!db.faculty.Any(x => x.id == fac.id))
            {
                return NotFound();
            }

            db.Update(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }

        // Delete api/students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Faculty>> Delete(int id)
        {
            Faculty fac = db.faculty.FirstOrDefault(x => x.id == id);
            if (fac == null)
            {
                return NotFound();
            }
            db.faculty.Remove(fac);
            await db.SaveChangesAsync();
            return Ok(fac);
        }
    }
}
