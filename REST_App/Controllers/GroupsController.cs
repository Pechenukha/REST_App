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
    public class GroupsController : ControllerBase
    {
        CollegeContext db;

        public GroupsController(CollegeContext context)
        {
            db = context;
            if (!db.groups.Any())
            {
                db.groups.Add(new Group { id = 1, number_of_group = "12919/1", curator = "Mrs. Wolf" });
                db.groups.Add(new Group { id = 2, number_of_group = "22919/1", curator = "Mr. Wolf" });
                db.SaveChanges();
            }
        }

        // GET: api/groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            return await db.groups.ToListAsync();
        }

        // POST api/groups
        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group gr)
        {
            if (gr == null)
            {
                return BadRequest();
            }

            db.groups.Add(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }

        // PUT api/groups
        [HttpPut]
        public async Task<ActionResult<Group>> Put(Group gr)
        {
            if (gr == null)
            {
                return BadRequest();
            }
            if (!db.groups.Any(x => x.id == gr.id))
            {
                return NotFound();
            }

            db.Update(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }

        // Delete api/groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> Delete(int id)
        {
            Group gr = db.groups.FirstOrDefault(x => x.id == id);
            if (gr == null)
            {
                return NotFound();
            }
            db.groups.Remove(gr);
            await db.SaveChangesAsync();
            return Ok(gr);
        }
    }
}
