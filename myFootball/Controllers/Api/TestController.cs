using AutoMapper;
using myFootball.Dtos;
using myFootball.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using myFootball.ViewModels;

namespace myFootball.Controllers.Api
{
    public class TestController : ApiController
    {

        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();
        }



        //GET api/test
        [Route("api/test/{TestId}")]
        [HttpGet]
        public IHttpActionResult GetTest(int TestId)
        {
            var query = $"SELECT p.Name FROM dbo.Players AS p INNER JOIN dbo.Results AS r ON p.Id = r.PlayerId WHERE r.TestId = '{TestId}'";
            var result = _context.Database.SqlQuery<TestResult>(query).ToList();

            return Ok(result);
        }



        //POST api/test
        [HttpPost]
        public IHttpActionResult CreateTest(TestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var test = Mapper.Map<TestDto, Test>(testDto);

            _context.Tests.Add(test);
            _context.SaveChanges();

            testDto.Id = test.Id;
            return Created(new Uri(Request.RequestUri + test.Id.ToString()), testDto);
        }


        //PUT api/addplayertotest/1/1
        [Route("api/test/addplayertotest/{TestId}/{PlayerId}")]
        [HttpPut]
        public IHttpActionResult AddPlayerToTest(int TestId, int PlayerId)
        {
            //checking if test and player exists in database
            var result = _context.Database.SqlQuery<string>($"SELECT id FROM dbo.Results WHERE Results.PlayerId = '{PlayerId}' AND Results.TestId = '{TestId}'").Count();        
            
            if(result == 0) 
            {
                try {
                    var query = $"INSERT INTO dbo.Results (PlayerId, TestId, ExamId, Score) VALUES ('{PlayerId}', '{TestId}', '0', '0')";
                    var db = _context.Database.ExecuteSqlCommand(query);

                    return Content(HttpStatusCode.Accepted, "Player was added correctly to test.");
                } catch
                {
                    return Content(HttpStatusCode.Conflict, "Cannot add player to test.");
                }
                
            } else
            {
                return Content(HttpStatusCode.BadRequest, "Player is already added to this test.");
            }            
        }


        //aorawiec delete player HTTP DELEETE

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}