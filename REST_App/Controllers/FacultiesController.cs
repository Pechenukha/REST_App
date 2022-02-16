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
        private readonly IConfiguration _configuration;

        public FacultiesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/faculties
        [HttpGet]
        public JsonResult Get()
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"select * from faculty";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        // POST api/faculties
        [HttpPost]
        public JsonResult Post(Faculty fac)
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"insert into faculty values (@id,@name,@head)";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", fac.Id);
                    myCommand.Parameters.AddWithValue("@name", fac.Name);
                    myCommand.Parameters.AddWithValue("@head", fac.Head);
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
        public JsonResult Put(Faculty fac)
        {
            string sqlDataSource = _configuration.GetConnectionString("StudentAppCon");
            string query = @"update faculty 
                        set name_of_faculty=@name,head_of_faculty=@head
                        where id=@id";

            DataTable table = new DataTable();
            NpgsqlDataReader myReader;

            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", fac.Id);
                    myCommand.Parameters.AddWithValue("@name", fac.Name);
                    myCommand.Parameters.AddWithValue("@head", fac.Head);
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
            string query = @"delete from faculty 
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
