using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using REST_App.Models;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace REST_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly IConfiguration _configuration;

        CollegeContext db;

        //public StudentsController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public StudentsController(CollegeContext context)
        {
            db = context;
            if (!db.student.Any())
            {
                db.student.Add(new Student { id = 1, name = "Tom Grant", course=2, id_faculty=1, speciality = "Maths and electronics" });
                db.student.Add(new Student { id = 2, name = "Eva Queen", course = 1, id_faculty = 2, speciality = "Classic vocal" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return await db.student.ToListAsync();
        }


        // GET: api/students
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    //string con = "Host=localhost;Port=5432;Username=postgres;Password=laptop14032020;Database=RestDB";
        //    string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
        //    string query = @"select * from student";

        //    DataTable table = new DataTable();
        //    NpgsqlDataReader myReader;

        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query,myCon)) 
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}


        // POST api/students
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student stud)
        {
            if (stud == null)
            {
                return BadRequest();
            }

            db.student.Add(stud);
            await db.SaveChangesAsync();
            return Ok(stud);
        }

        //[HttpPost]
        //public JsonResult Post(Student stud)
        //{
        //    string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
        //    string query = @"insert into student values (@id,@name,@cour,@fac,@spec)";

        //    DataTable table = new DataTable();
        //    NpgsqlDataReader myReader;

        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id",stud.Id);
        //            myCommand.Parameters.AddWithValue("@name", stud.Name);
        //            myCommand.Parameters.AddWithValue("@cour", stud.Course);
        //            myCommand.Parameters.AddWithValue("@fac", stud.Faculty);
        //            myCommand.Parameters.AddWithValue("@spec", stud.Speciality);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Added successfully");
        //}

        // PUT api/students
        [HttpPut]
        public async Task<ActionResult<Student>> Put(Student stud)
        {
            if (stud == null)
            {
                return BadRequest();
            }
            if (!db.student.Any(x => x.id == stud.id))
            {
                return NotFound();
            }

            db.Update(stud);
            await db.SaveChangesAsync();
            return Ok(stud);
        }

        //[HttpPut]
        //public JsonResult Put(Student stud)
        //{
        //    string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
        //    string query = @"update student 
        //                set name=@name,course=@cour,faculty=@fac,speciality=@spec
        //                where id=@id";

        //    DataTable table = new DataTable();
        //    NpgsqlDataReader myReader;

        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", stud.Id);
        //            myCommand.Parameters.AddWithValue("@name", stud.Name);
        //            myCommand.Parameters.AddWithValue("@cour", stud.Course);
        //            myCommand.Parameters.AddWithValue("@fac", stud.Faculty);
        //            myCommand.Parameters.AddWithValue("@spec", stud.Speciality);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Updated successfully");
        //}

        // Delete api/students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            Student stud = db.student.FirstOrDefault(x => x.id == id);
            if (stud == null)
            {
                return NotFound();
            }
            db.student.Remove(stud);
            await db.SaveChangesAsync();
            return Ok(stud);
        }

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
        //    string query = @"delete from student 
        //                where id=@id";

        //    DataTable table = new DataTable();
        //    NpgsqlDataReader myReader;

        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", id);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult("Delete successfully");
        //}
    }
}
