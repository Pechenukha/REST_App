using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using REST_App.Models;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;


namespace REST_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/students
        [HttpGet]
        public JsonResult Get()
        {
            //string con = "Host=localhost;Port=5432;Username=postgres;Password=laptop14032020;Database=RestDB";
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"select * from student";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query,myCon)) 
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        // POST api/students
        [HttpPost]
        public JsonResult Post(Student stud)
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"insert into student values (@id,@name,@cour,@fac,@spec)";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id",stud.Id);
                    myCommand.Parameters.AddWithValue("@name", stud.Name);
                    myCommand.Parameters.AddWithValue("@cour", stud.Course);
                    myCommand.Parameters.AddWithValue("@fac", stud.Faculty);
                    myCommand.Parameters.AddWithValue("@spec", stud.Speciality);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added successfully");
        }

        // PUT api/students
        [HttpPut]
        public JsonResult Put(Student stud)
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"update student 
                        set name=@name,course=@cour,faculty=@fac,speciality=@spec
                        where id=@id";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", stud.Id);
                    myCommand.Parameters.AddWithValue("@name", stud.Name);
                    myCommand.Parameters.AddWithValue("@cour", stud.Course);
                    myCommand.Parameters.AddWithValue("@fac", stud.Faculty);
                    myCommand.Parameters.AddWithValue("@spec", stud.Speciality);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }

        // Delete api/students/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"delete from student 
                        where id=@id";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Delete successfully");
        }
    }
}
